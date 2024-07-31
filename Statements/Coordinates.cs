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
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            this.getCoordinates();
        }

        private void getCoordinates()
        {
            this.X = RegEx.returnFloat('X', this.GCode);
            this.Y = RegEx.returnFloat('Y', this.GCode);
            this.Z = RegEx.returnFloat('Z', this.GCode);
        }

        internal void setMinX(State.State st)
        {
            if (st.MinX > this.X) { st.MinX = this.X; }
        }
        internal void setMaxX(State.State st)
        {
            if (st.MaxX < this.X) { st.MaxX = this.X; }
        }
        internal void setMinY(State.State st)
        {
            if (st.MinY > this.Y) { st.MinY = this.Y; }
        }
        internal void setMaxY(State.State st)
        {
            if (st.MaxY < this.Y) { st.MaxY = this.Y; }
        }
        internal void setMinZ(State.State st)
        {
            if (st.MinZ > this.Z) { st.MinZ = this.Z; }
        }
        internal void setMaxZ(State.State st)
        {
            if (st.MaxZ < this.Z) { st.MaxZ = this.Z; }
        }
        internal void setBounds(State.State st)
        {
            this.setMinX(st);
            this.setMaxX(st);
            this.setMinY(st);
            this.setMaxY(st);
            this.setMinZ(st);
            this.setMaxZ(st);
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

            this.setBounds(st);
        }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
