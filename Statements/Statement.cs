using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MotionPlanning.State;

namespace MotionPlanning.Statements
{
    public abstract class Statement : IURScript
    {
        /// <summary>
        ///	An abstract base class for statements
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public Statement(string gcode) 
        {
            this.GCode = gcode;
        }

        // A string containing the full G-Code statement
        public string GCode { get; set; }

        // The command type of the G-Code statement
        public char CommandType { get; set; }

        // The command number of the G-Code statement
        public int CommandNumber { get; set; }

        // Indication if the G-Code statement provided is valid
        public bool Valid { get; set; }

        /// <summary>
        ///	An abstract method to return an URScript statement
        ///	based on the G-Code provided
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        public abstract string URScript(State.State st);
    }
}
