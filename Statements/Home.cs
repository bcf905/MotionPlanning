using MotionPlanning.Coordinates;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Statements
{
    public class Home : Coordinates
    {
        /// <summary>
        ///	A class for the G-Code command: Home
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="gcode">A string containing the full G-Code statement</param>
        /// <returns>Null</returns>
        public Home(string gcode) : base(gcode)
        {
            this.Valid = true;
            this.CommandType = 'G';
            this.CommandNumber = 28;
        }

        /// <summary>
        ///	A method to return an URScript statement
        ///	for the G-Code command: Home
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>A string containing the URScript statement</returns>
        override public string URScript(State.State st)
        {
            // Getting the destination's coordinate (center of workspace)
            this.X = st.Workspace.Origin.X;
            this.Y = st.Workspace.Origin.Y;
            this.Z = st.Workspace.Origin.Z;

            // Calculating the velocity to move robot 
            double velocity = Auxiliary.Convert.FeedrateToTime(1000, this.Distance(st));

            string script = $"movel({this.GetPose(st)}, t={velocity.ToString("f3", CultureInfo.InvariantCulture)})\n";

            // Setting current coordinate values
            this.SetCurrentCoordinates(st);

            // returning URScript command
            return script;
        }
    }
}
