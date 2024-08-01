using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Statements;
using MotionPlanning.Job;

namespace MotionPlanning.Auxiliary
{
    /// <summary>
    ///	Auxiliary functions to identify G-Code
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>Void</returns>
    public class Identifier
    {
        /// <summary>
        ///	A method that identifies a G-Code command type
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing a G-Code statement</param>
        /// <returns>A char. Either 'G' or 'M'. Contains char.MinValue if command type not found</returns>
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

        /// <summary>
        ///	A method that identifies a G-Code command number
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="commandtype">A char containing the command type</param>
        /// <param name="gcode">A string containing a G-Code statement</param>
        /// <returns>A int containing the command number. Contains int.MinValue if command number not found</returns>
        private static int getCommandNumber(char commandtype, string gcode)
        {
            return RegEx.returnInteger(commandtype, gcode);
        }

        /// <summary>
        ///	A method that identifies a G-Code statement
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing a G-Code statement</param>
        /// <param name="job">A Job object to store bounds</param>
        /// <returns>A int containing the command number. Contains int.MinValue if command number not found</returns>
        public static IURScript Identify(string gcode, Job.Job job)
        {
            IURScript statement = new Invalid(gcode);
            char commandtype = getCommandType(gcode);
            if (commandtype != char.MinValue)
            {
                int commandnumber = getCommandNumber(commandtype, gcode);

                switch (commandnumber)
                {
                    case 0: // Rapid Move
                        RapidMove rapidmove = new RapidMove(gcode);
                        job.setBounds(rapidmove.X, rapidmove.Y, rapidmove.Z);
                        statement = (IURScript) rapidmove;
                        break;
                    case 1: // Linear Move
                        LinearMove linearmove = new LinearMove(gcode);
                        job.setBounds(linearmove.X, linearmove.Y, linearmove.Z);
                        statement = (IURScript) linearmove;
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
                        SetCurrentPosition setcurrentposition = new SetCurrentPosition(gcode);
                        job.setBounds(setcurrentposition.X, setcurrentposition.Y, setcurrentposition.Z);
                        statement = (IURScript) setcurrentposition;
                        break;
                }
            }
            return statement;
        }
    }
}
