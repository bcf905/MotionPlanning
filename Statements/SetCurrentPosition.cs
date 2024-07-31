using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class SetCurrentPosition : Coordinates
    {
        /// <summary>
        ///	A class for the G-Code command: Set Current Position
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public SetCurrentPosition(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 92;
        }

        /// <summary>
        ///	A method to return an URScript statement
        ///	for the G-Code command: Set Current Position
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        override public string URScript(State.State st)
        {
            return $"Set Current Position";
        }
    }
}
