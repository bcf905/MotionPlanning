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
        public Coordinates(string gcode) : base(gcode)
        {
            this.X = float.MinValue;
            this.Y = float.MinValue;
            this.Z = float.MinValue;

            this.getCoordinates();
        }

        private void getCoordinates()
        {
            this.X = RegEx.returnFloat('X', this.GCode);
            this.Y = RegEx.returnFloat('Y', this.GCode);
            this.Z = RegEx.returnFloat('Z', this.GCode);
        }

        internal void setStateCoordinates(State.State st)
        {
            if (!st.Millimeter)
            {
                this.X = Auxiliary.Convert.InchesToMillimeter(this.X);
                this.Y = Auxiliary.Convert.InchesToMillimeter(this.Y);
                this.Z = Auxiliary.Convert.InchesToMillimeter(this.Z);
            }
            if (st.Relative)
            {
                st.X += this.X;
                st.Y += this.Y;
                st.Z += this.Z;

            }
            else
            {
                st.X = this.X;
                st.Y = this.Y;
                st.Z = this.Z;
            }

        }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
