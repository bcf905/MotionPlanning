using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.State;

namespace MotionPlanning.Statements
{
    public class LinearMove : Coordinates
    {
        public LinearMove(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 1;
        }
        override public string URScript(State.State st)
        {
            return $"Linear Move - " +
                $"X:{this.X.ToString("f3", CultureInfo.InvariantCulture)}, " +
                $"Y:{this.Y.ToString("f3", CultureInfo.InvariantCulture)}, " +
                $"Z:{this.Z.ToString("f3", CultureInfo.InvariantCulture)}";
        }
    }
}
