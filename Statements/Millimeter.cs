using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class Millimeter : Statement
    {
        public Millimeter(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 21;
        }
        override public string URScript(State.State st)
        {
            st.Millimeter = true;
            return "Millimeter";
        }
    }
}
