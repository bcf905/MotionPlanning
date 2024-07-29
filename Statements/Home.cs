using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class Home : Statement
    {
        public Home(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 28;
        }
        override public string URScript(State.State st)
        {
            return "Home";
        }
    }
}
