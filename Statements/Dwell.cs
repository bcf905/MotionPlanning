using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Auxiliary;

namespace MotionPlanning.Statements
{
    public class Dwell : Statement
    {
        /// <summary>
        ///	A class for the G-Code command: Dwell
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public Dwell(string gcode) : base(gcode)
        {
            this.Valid = false;
            this.CommandType = 'G';
            this.CommandNumber = 4;
            this.WaitInSeconds = true;
            this.WaitingTime = float.MinValue;
            this.getWaitingTime();
        }

        /// <summary>
        ///	A method to return an URScript statement
        ///	for the G-Code command: Dwell
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        override public string URScript(State.State st)
        {
            if (!this.WaitInSeconds)
            {
                this.WaitingTime = Auxiliary.Convert.MillisecondsToSeconds(this.WaitingTime);
                this.WaitInSeconds = true;
            }
            return $"sleep({this.WaitingTime.ToString("f3", CultureInfo.InvariantCulture)}) \n";
        }

        /// <summary>
        ///	A method that gets the time parameter 
        ///	from the G-Code command: Dwell
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>Void</returns>
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

        // Indicates wether WaitingTime is in seconds or milliseconds
        // Is true if time is in seconds
        public bool WaitInSeconds { get; set; }

        // Contains the time of waiting
        public float WaitingTime { get; set; }
    }
}
