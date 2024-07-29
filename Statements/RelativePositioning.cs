using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class RelativePositioning : Statement
    {
        public RelativePositioning(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 91;
        }
        override public string URScript(State.State st)
        {
            st.Relative = true;
            return "Relative Positioning";
        }
    }
}
