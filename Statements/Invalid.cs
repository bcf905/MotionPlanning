using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class Invalid : Statement
    {
        /// <summary>
        ///	A class for not supported G-Code commands
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public Invalid(string gcode) : base(gcode)
        {
            this.Valid = false;
            this.CommandType = char.MinValue;
            this.CommandNumber = int.MinValue;
        }

        /// <summary>
        ///	A method to return an URScript statement
        ///	for not supported G-Code commands
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        override public string URScript(State.State st)
        {
            return "";
        }

    }
}
