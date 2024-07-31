using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MotionPlanning.State;

namespace MotionPlanning.Statements
{
    public class RapidMove : Coordinates
    {
        /// <summary>
        ///	A class for the G-Code command: Rapid Move
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public RapidMove(string gcode) : base(gcode) 
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 0;
        }

        /// <summary>
        ///	A method to return an URScript statement
        ///	for the G-Code command: Rapid Move
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        override public string URScript(State.State st)
        {
            this.setStateCoordinates(st);
            return $"Rapid Move - " +
                $"X:{this.X.ToString("f3", CultureInfo.InvariantCulture)}, " +
                $"Y:{this.Y.ToString("f3", CultureInfo.InvariantCulture)}, " +
                $"Z:{this.Z.ToString("f3", CultureInfo.InvariantCulture)}";
        }
    }
}
