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
            // Calculating new shifting values

            if (this.X == float.MinValue && this.Y == float.MinValue && this.Z == float.MinValue)
            {
                // no coordinates provided => all axes is set to zero
                st.XShift = st.X;
                st.YShift = st.Y;
                st.ZShift = st.Z;
            }
            else
            {
                st.XShift = (this.X == float.MinValue) ? st.XShift : (st.X - this.X) ;
                st.YShift = (this.Y == float.MinValue) ? st.YShift : (st.Y - this.Y);
                st.ZShift = (this.Z == float.MinValue) ? st.ZShift : (st.Z - this.Z);
            }

            return "";
        }
    }
}
