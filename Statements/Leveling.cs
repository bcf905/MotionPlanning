using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class Leveling : Coordinates
    {
        public Leveling(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 29;
        }
        override public string URScript(State.State st)
        {
            return "Leveling";
        }
    }
}
