using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.State
{
    // A container for a job's settings and current position 
    public class State
    {
        public State() 
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            this.Relative = false;
            this.Millimeter = true;
            this.XShift = 0;
            this.YShift = 0;
            this.ZShift = 0;
        }

        // When true the setting is relative positioning
        // When false the setting is absolute positioning
        public bool Relative { get; set; }
        // When true the setting is millimeter
        // When false the setting is inches
        public bool Millimeter { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float XShift { get; set; }
        public float YShift { get; set; }
        public float ZShift { get; set; }
    }
}
