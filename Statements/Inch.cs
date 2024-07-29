using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class Inch : Statement
    {
        public Inch(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 20;
        }
        override public string URScript(State.State st)
        {
            st.Millimeter = false;
            return "Inch";
        }
    }
}
