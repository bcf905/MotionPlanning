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

            // Adding coordinates from State object if setting is relative positioning
            if (st.Relative)
            {
                this.X += st.X;
                this.Y += st.Y;
                this.Z += st.Z;

            }

            // Shifting values
            this.X += st.XShift;
            this.Y += st.YShift;
            this.Z += st.ZShift;


        }

        internal void SetCurrentCoordinates(State.State st)
        {
            st.X = this.X;
            st.Y = this.Y;
            st.Z = this.Z;
        }

        internal string GetPose(State.State st)
        {
            // creating pose
            string pose = $"p[";

            if (this.X > float.MinValue)
            {
                // Setting x value if parameter is present i G-Code
                pose += $"{this.X},";
            }
            else
            {
                // Setting current x value of pararmeter not present in G-Code
                pose += $"{st.X},";
            }

            if (this.Y > float.MinValue)
            {
                // Setting y value if parameter is present i G-Code
                pose += $"{this.Y},";
            }
            else
            {
                // Setting current y value of pararmeter not present in G-Code
                pose += $"{st.Y},";
            }

            if (this.Z > float.MinValue)
            {
                // Setting z value if parameter is present i G-Code
                pose += $"{this.Z},";
            }
            else
            {
                // Setting current z value of pararmeter not present in G-Code
                pose += $"{st.Z},";
            }

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
            // Calculating the distance in statement            
            return Math.Sqrt(Math.Pow(this.X - st.X, 2.0f) + Math.Pow(this.Y - st.Y, 2.0f));

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
