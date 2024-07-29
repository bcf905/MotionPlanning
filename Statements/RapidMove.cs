using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MotionPlanning.State;

namespace MotionPlanning.Statements
{
    public class RapidMove : Coordinates
    {
        public RapidMove(string gcode) : base(gcode) 
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 0;
        }
        override public string URScript(State.State st)
        {
            this.setStateCoordinates(st);
            return $"Rapid Move - " +
                $"X:{this.X.ToString("f3", CultureInfo.InvariantCulture)}, " +
                $"Y:{this.Y.ToString("f3", CultureInfo.InvariantCulture)}, " +
                $"Z:{this.Z.ToString("f3", CultureInfo.InvariantCulture)}";
        }
    }
}
