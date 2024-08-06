using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.State
{
    public class State
    {
        /// <summary>
        ///	A container for a job's settings and current position 
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>Null</returns>
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

        // Current X position
        public float X { get; set; }

        // Current Y position
        public float Y { get; set; }

        // Current Z position
        public float Z { get; set; }

        // Shifting value for X - used to center job in workspace
        public float XShift { get; set; }

        // Shifting value for Y - used to center job in workspace
        public float YShift { get; set; }

        // Shifting value for Z - used to center job in workspace
        public float ZShift { get; set; }

        // A container for the current workspace
        public Workspace.Workspace Workspace { get; set; }
    }
}
