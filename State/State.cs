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
            this.MinX = 0;
            this.MinY = 0;
            this.MinZ = 0;
            this.MaxX = 0;
            this.MaxY = 0;
            this.MaxZ = 0;
            this.Relative = false;
            this.Millimeter = true;
        }

        // When true the setting is relative positioning
        // When false the setting is absolute positioning
        public bool Relative { get; set; }
        // When true the setting is millimeter
        // When false the setting is inches
        public bool Millimeter { get; set; }

        public float X { get; set; }
        public float MinX { get; set; }
        public float MaxX { get; set; }
        public float Y { get; set; }
        public float MinY { get; set; }
        public float MaxY { get; set; }
        public float Z { get; set; }
        public float MinZ { get; set; }
        public float MaxZ { get; set; }
    }
}
