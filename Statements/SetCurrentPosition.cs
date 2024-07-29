using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class SetCurrentPosition : Coordinates
    {
        public SetCurrentPosition(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 92;
        }
        override public string URScript(State.State st)
        {
            return $"Set Current Position";
        }
    }
}
