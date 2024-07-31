using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.State;
using MotionPlanning.Auxiliary;

namespace MotionPlanning.Statements
{
    public abstract class Coordinates : Statement
    {
        /// <summary>
        ///	An abstract class for statements that uses coordinates
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public Coordinates(string gcode) : base(gcode)
        {
            this.X = float.MinValue;
            this.Y = float.MinValue;
            this.Z = float.MinValue;

            this.getCoordinates();
        }

        /// <summary>
        ///	Extracting coordinates from G-Code provided
        ///	and assign them to the appropriated attributes
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>Null</returns>
        private void getCoordinates()
        {
            this.X = RegEx.returnFloat('X', this.GCode);
            this.Y = RegEx.returnFloat('Y', this.GCode);
            this.Z = RegEx.returnFloat('Z', this.GCode);
        }

        /// <summary>
        /// Assigning coordinates to the State object provided
        ///	Extracting coordinates from G-Code provided
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>Null</returns>
        internal void setStateCoordinates(State.State st)
        {
            // Converts to millimeter if coordinates is inches
            if (!st.Millimeter)
            {
                this.X = Auxiliary.Convert.InchesToMillimeter(this.X);
                this.Y = Auxiliary.Convert.InchesToMillimeter(this.Y);
                this.Z = Auxiliary.Convert.InchesToMillimeter(this.Z);
            }

            // Adding coordinates to State object if setting is relative positioning
            if (st.Relative)
            {
                st.X += this.X;
                st.Y += this.Y;
                st.Z += this.Z;

            }
            // Assigning coordinates to State object if setting is absolute positioning
            else
            {
                st.X = this.X;
                st.Y = this.Y;
                st.Z = this.Z;
            }

        }

        // Contains the x coordinate from the G-Code
        // If none provided the value is float.MinValue
        public float X { get; set; }

        // Contains the y coordinate from the G-Code
        // If none provided the value is float.MinValue
        public float Y { get; set; }

        // Contains the z coordinate from the G-Code
        // If none provided the value is float.MinValue
        public float Z { get; set; }
    }
}
