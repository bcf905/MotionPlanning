using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Auxiliary;

namespace MotionPlanning.Statements
{
    public class Dwell : Statement
    {
        public Dwell(string gcode) : base(gcode)
        {
            this.Valid = false;
            this.CommandType = 'G';
            this.CommandNumber = 4;
            this.WaitInSeconds = true;
            this.WaitingTime = float.MinValue;
            this.getWaitingTime();
        }
        override public string URScript(State.State st)
        {
            return "Dwell";
        }

        private void getWaitingTime()
        {
            // Getting waiting time in milliseconds
            this.WaitingTime = Auxiliary.RegEx.returnFloat('P', this.GCode);

            if (this.WaitingTime == float.MinValue)
            {
                // Getting waiting time in seconds
                this.WaitingTime = Auxiliary.RegEx.returnFloat('S', this.GCode);
                if (this.WaitingTime != float.MinValue)
                {
                    this.Valid = true;
                }
            }
            else
            {
                this.Valid = true;
                this.WaitInSeconds = false;
            }

        }
        public bool WaitInSeconds { get; set; }
        public float WaitingTime { get; set; }
    }
}
