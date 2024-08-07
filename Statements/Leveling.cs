using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class Leveling : Coordinates
    {
        /// <summary>
        ///	A class for the G-Code command: Leveling
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public Leveling(string gcode) : base(gcode)
        {
            // not implemented => invalid statement
            this.Valid = false;
            this.CommandType = 'G';
            this.CommandNumber = 29;
        }

        /// <summary>
        ///	A method to return an URScript statement
        ///	for the G-Code command: Leveling
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        override public string URScript(State.State st)
        {
            // not possible to use probe
            return "";
        }
    }
}
