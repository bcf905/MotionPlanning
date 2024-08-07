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
                this.X = (this.X == float.MinValue) ? float.MinValue : Auxiliary.Convert.InchesToMillimeter(this.X);
                this.Y = (this.Y == float.MinValue) ? float.MinValue : Auxiliary.Convert.InchesToMillimeter(this.Y);
                this.Z = (this.Z == float.MinValue) ? float.MinValue : Auxiliary.Convert.InchesToMillimeter(this.Z);
            }

            // Adding coordinates from State object if setting is relative positioning
            if (st.Relative)
            {
                this.X = (this.X == float.MinValue) ? st.X : st.X + this.X;
                this.Y = (this.Y == float.MinValue) ? st.Y : st.Y + this.Y;
                this.Z = (this.Z == float.MinValue) ? st.Z : st.Z + this.Z;

            }

            // Shifting values
            this.X = (this.X == float.MinValue) ? st.X : this.X + st.XShift;
            this.Y = (this.Y == float.MinValue) ? st.Y : this.Y + st.YShift;
            this.Z = (this.Z == float.MinValue) ? st.Z : this.Z + st.ZShift;


        }

        internal void SetCurrentCoordinates(State.State st)
        {
            // Setting x value if parameter is present i G-Code
            st.X = (this.X == float.MinValue) ? st.X : this.X;

            // Setting y value if parameter is present i G-Code
            st.Y = (this.Y == float.MinValue) ? st.Y : this.Y;

            // Setting z value if parameter is present i G-Code
            st.Z = (this.Z == float.MinValue) ? st.Z : this.Z;
        }

        internal string GetPose(State.State st)
        {
            // creating pose
            string pose = $"p[";

            // Setting x value if parameter is present i G-Code
            pose += (this.X == float.MinValue) ? $"{st.X}," : $"{this.X},";

            // Setting y value if parameter is present i G-Code
            pose += (this.Y == float.MinValue) ? $"{st.Y}," : $"{this.Y},";

            // Setting z value if parameter is present i G-Code
            pose += (this.Z == float.MinValue) ? $"{st.Z}," : $"{this.Z},";

            // Getting toolpostition
            pose += st.Workspace.GetToolposition();

            pose += "]";

            return pose;
        }

        /// <summary>
        /// Calculating the distance from one statement to the next
        /// </summary>
        /// <remarks>
        /// The distance is only calculated in 2 dimensions, since there will
        /// be no printing in 3 dimensions.
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A float containing the distance in millimeter</returns>
        internal double Distance(State.State st)
        {
            float x, y;

            x = (this.X == float.MinValue) ? st.X : this.X;
            y = (this.Y == float.MinValue) ? st.Y : this.Y;

            // Calculating the distance in statement            
            return Math.Sqrt(Math.Pow(x - st.X, 2.0f) + Math.Pow(y - st.Y, 2.0f));

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
