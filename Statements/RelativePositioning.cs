using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class RelativePositioning : Statement
    {
        /// <summary>
        ///	A class for the G-Code command: Relative Positioning
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public RelativePositioning(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 91;
        }

        /// <summary>
        ///	A method to change the setting in State object
        ///	to Relative Positioning
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        override public string URScript(State.State st)
        {
            st.Relative = true;
            return "Relative Positioning";
        }
    }
}
