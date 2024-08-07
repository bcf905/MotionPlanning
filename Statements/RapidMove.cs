﻿using System;
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
        /// <summary>
        ///	A class for the G-Code command: Rapid Move
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public RapidMove(string gcode) : base(gcode) 
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 0;
        }

        /// <summary>
        ///	A method to return an URScript statement
        ///	for the G-Code command: Rapid Move
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        override public string URScript(State.State st)
        {
            this.setStateCoordinates(st);

            // Calculating the velocity to move robot 
            double velocity = Auxiliary.Convert.FeedrateToTime(st.Workspace.Feedrate, this.Distance(st));

            string script = $"movel({this.GetPose(st)}, t={velocity.ToString("f3", CultureInfo.InvariantCulture)})\n";

            // Setting current coordinate values
            this.SetCurrentCoordinates(st);

            // returning URScript command
            return script;
        }
    }
}
