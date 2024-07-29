using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning
{
    public class Statement
    {


        public Statement(string gcode) 
        {
            this.GCode = gcode;
            this.Command = CommandType.None;
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            this.Valid = false;
            this.Validate();
        }
        public string GCode { get; set; }
        public CommandType Command { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public bool Valid { get; set; }
        private void GetCoordinates()
        {
            this.X = RegEx.returnFloat('X', this.GCode);
            this.Y = RegEx.returnFloat('Y', this.GCode);
            this.Z = RegEx.returnFloat('Z', this.GCode);
        }
        private void Validate()
        {
            string pattern = @"^G";
            Valid = RegEx.isMatch(pattern, this.GCode);
            if (Valid)
            {
                this.Valid = true;
                this.GetCoordinates();
                switch (RegEx.returnInteger('G', this.GCode))
                {
                    // Rapid Move
                    case 0:
                        this.Command = CommandType.RapidMove;
                        break;

                    // Linear Move
                    case 1:
                        this.Command = CommandType.LinearMove;
                        break;

                    // Dwell
                    case 4:
                        this.Command = CommandType.Dwell;
                        break;
                    
                    // Inches
                    case 20:
                        this.Command = CommandType.Inches;
                        break;

                    // Millimeters
                    case 21:
                        this.Command = CommandType.Millimeters;
                        break;

                    // Home
                    case 28:
                        this.Command = CommandType.Home;
                        break;

                    // Leveling
                    case 29:
                        this.Command = CommandType.Leveling;
                        break;

                    // Absolute Positioning
                    case 90:
                        this.Command = CommandType.AbsolutePositioning;
                        break;

                    // Relative Positioning
                    case 91:
                        this.Command = CommandType.RelativePositioning;
                        break;

                    // Set Current Position
                    case 92:
                        this.Command = CommandType.SetCurrentPosition;
                        break;
                }
            }

        }
        public string URScript() { return string.Empty; }
    }
}
