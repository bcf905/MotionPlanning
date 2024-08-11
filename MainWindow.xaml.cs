using MotionPlanning.Auxiliary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MotionPlanning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool fileValid = false;
        bool conversionValid = false;
        bool workspaceValid = false;
        Workspace.Workspace? workspace;
        Job.Job? job;

        public MainWindow()
        {
            InitializeComponent();
            IsReady();
        }

        /// <summary>
        ///	Opens a file dialog and let the user choose a location
        ///	for a file with gcode as extension.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="sender">Reference to the object that has raised this event</param>
        /// <param name="e">All routed event data</param>
        /// <returns>Void</returns>
        private void submitChooseFile_Click(object sender, RoutedEventArgs e)
        {
            // Create File Dialog
            Microsoft.Win32.OpenFileDialog dlg  = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension
            dlg.DefaultExt = ".gcode";
            dlg.Filter = "G-CODE FILES (*.gcode)|*.gcode";

            // Display File Dialog
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file
            if (result == true)
            {
                // Open file
                string filename = dlg.FileName;
                fileNameText.Text = filename;
                fileValid = true;
                IsReady();
            }
        }


        private void IsReady()
        {
            if (fileValid && conversionValid && workspaceValid)
            {
                submitStartJob.IsEnabled = true;
            }
            else
            {
                submitStartJob.IsEnabled = false;
            }
        }
        private bool ValidateFile()
        {
            try
            {

                // Checking if there is a location
                string fileLocation = fileNameText.Text;
                if (fileLocation == null || fileLocation == "")
                {
                    throw new FileNotFoundException("No file specified!");
                }

                // Checking if type of file is correct
                string fileExtension = fileLocation.Substring(fileLocation.LastIndexOf(".") + 1);
                if (fileExtension != "gcode")
                {
                    throw new FileNotFoundException($"{fileExtension} is not supported.");
                }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        private void submitTestWorkspace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // corner 1 x value
                if (!int.TryParse(txtCoord1X.Text, out int coord1X))
                {
                    throw new Exception("Corner 1: x value is not a number!");
                }

                // corner 1 y value
                if (!int.TryParse(txtCoord1Y.Text, out int coord1Y))
                {
                    throw new Exception("Corner 1: y value is not a number!");
                }

                // corner 2 x value
                if (!int.TryParse(txtCoord2X.Text, out int coord2X))
                {
                    throw new Exception("Corner 2: x value is not a number!");
                }

                // corner 2 y value
                if (!int.TryParse(txtCoord2Y.Text, out int coord2Y))
                {
                    throw new Exception("Corner 2: y value is not a number!");
                }

                // height value 
                if (!int.TryParse(txtHeight.Text, out int height))
                {
                    throw new Exception("Height value is not a number!");
                }

                // z-offset value
                if (!int.TryParse(txtOffsetZ.Text, out int offsetZ))
                {
                    throw new Exception("Z-offset value is not a number!");
                }

                // feedrate
                if (!int.TryParse(txtFeedrate.Text, out int feedrate))
                {
                    throw new Exception("Feedrate value is not an integer!");
                }
                else
                {
                    if (feedrate <= 0) { throw new Exception("Feedrate has to be a positive number!"); }
                }

                // extrude
                if (!float.TryParse(txtExtrude.Text, out float extrude))
                {
                    throw new Exception("Extrude value is not a number!");
                }
                else
                {
                    if (extrude <= 0 || extrude > 1) 
                    { 
                        throw new Exception("The extrude has to be greater than zero and maximum 1!"); 
                    }
                }

                // IP address
                string pattern = @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$";
                if (!Auxiliary.RegEx.isMatch(pattern, txtIP.Text))
                {
                    throw new Exception("IP address is not valid!");
                }

                Coordinates.Coordinate2D coord1 = new(coord1X, coord1Y);
                Coordinates.Coordinate2D coord2 = new(coord2X, coord2Y);
                workspace = new(coord1, coord2, height, offsetZ);
                workspace.IPAddress = txtIP.Text;
                workspace.Feedrate = feedrate;
                workspace.Extrude = extrude;
                string result = Auxiliary.RobotConnection.SendMessage(txtIP.Text, workspace.GetTestScript());
                MessageBox.Show(result, "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                workspaceValid = true;
                IsReady();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void submitConvert_Click(object sender, RoutedEventArgs e)
        {
            if (!workspaceValid)
            {
                MessageBox.Show("Workspace must pass test before converting G-Code!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ValidateFile())
                {
                    try
                    {
                        // Open file
                        StreamReader reader = new StreamReader(fileNameText.Text);
                        job = GCode.Read(reader, workspace);
                        conversionValid = true;
                        MessageBox.Show("G-Code converted to URSCript.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        IsReady();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("G-Code file selected is not valid!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void submitStartJob_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = Auxiliary.RobotConnection.SendMessage(workspace.IPAddress, URScript.CreateScript(job));

                MessageBox.Show("Instructions send to robot", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

