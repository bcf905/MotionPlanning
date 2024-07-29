using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class AbsolutePositioning : Statement
    {
        public AbsolutePositioning(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 90;
        }
        override public string URScript(State.State st)
        {
            st.Relative = false;
            return "Absolute Positioning";
        }
    }
}
