using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Statements;

namespace MotionPlanning.Auxiliary
{
    public class Identifier
    {
        private static char getCommandType(string gcode)
        {
            string pattern = @"^G";
            char result = char.MinValue;

            if (RegEx.isMatch(pattern, gcode))
            {
                result = 'G';
            }
            else
            {
                pattern = @"^M";
                if (RegEx.isMatch(pattern, gcode))
                {
                    result = 'M';
                }
            }
            return result;
        }
        private static int getCommandNumber(char commandtype, string gcode)
        {
            return RegEx.returnInteger(commandtype, gcode);
        }
        public static IURScript Identify(string gcode)
        {
            IURScript statement = new Invalid(gcode);
            char commandtype = getCommandType(gcode);
            if (commandtype != char.MinValue)
            {
                int commandnumber = getCommandNumber(commandtype, gcode);

                switch (commandnumber)
                {
                    case 0: // Rapid Move
                        statement = new RapidMove(gcode);
                        break;
                    case 1: // Linear Move
                        statement = new LinearMove(gcode);
                        break;
                    case 4: // Dwell
                        statement = new Dwell(gcode);
                        break;
                    case 20: // Inch
                        statement = new Inch(gcode);
                        break;
                    case 21: // Millimeter
                        statement = new Millimeter(gcode);
                        break;
                    case 28: // Home
                        statement = new Home(gcode);
                        break;
                    case 29: // Leveling
                        statement = new Leveling(gcode);
                        break;
                    case 90: // Absolute Positioning
                        statement = new AbsolutePositioning(gcode);
                        break;
                    case 91: // Relative Positioning
                        statement = new RelativePositioning(gcode);
                        break;
                    case 92: // Set Current Position
                        statement = new SetCurrentPosition(gcode);
                        break;
                }
            }
            return statement;
        }
    }
}
