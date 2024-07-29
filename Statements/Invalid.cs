using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class Invalid : Statement
    {
        public Invalid(string gcode) : base(gcode)
        {
            this.Valid = false;
            this.CommandType = char.MinValue;
            this.CommandNumber = int.MinValue;
        }
        override public string URScript(State.State st)
        {
            return "Not a valid command.";
        }

    }
}
