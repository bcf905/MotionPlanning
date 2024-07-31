using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.State;

namespace MotionPlanning.Statements
{
    public interface IURScript
    {
        /// <summary>
        ///	An interface for statements making the handler
        ///	able to iterate a collections of statements and derived objects
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="st">A State object that provides settings</param>
        /// <returns>Null</returns>
        string URScript(State.State st);

        // Indication if the G-Code statement provided is valid
        bool Valid { get; set; }

        // A string containing the full G-Code statement
        string GCode { get; set; }

        // The command type of the G-Code statement
        char CommandType { get; set; }

        // The command number of the G-Code statement
        int CommandNumber { get; set; }
    }
}
