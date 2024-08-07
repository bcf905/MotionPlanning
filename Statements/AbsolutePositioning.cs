using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class AbsolutePositioning : Statement
    {
        /// <summary>
        ///	A class for the G-Code command: Absolute Positioning
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public AbsolutePositioning(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 90;
        }

        /// <summary>
        ///	A method to change the setting in State object
        ///	to Absolute Positioning
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        override public string URScript(State.State st)
        {
            st.Relative = false;
            return "";
        }
    }
}
