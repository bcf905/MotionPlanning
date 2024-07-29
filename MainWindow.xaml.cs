using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        public MainWindow()
        {
            InitializeComponent();
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
            }
        }

        /// <summary>
        /// Validate the file seleted. 
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="sender">Reference to the object that has raised this event</param>
        /// <param name="e">All routed event data</param>
        /// <returns>Void</returns>
        private void submitValidateFile_Click(object sender, RoutedEventArgs e)
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

                // Open file
                StreamReader sr = new StreamReader(fileLocation);

                string result = MotionPlanning.File.readGCode(ref sr);
                if (result == "success") 
                {
                MessageBox.Show("Streamreader is done.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    throw new Exception(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
