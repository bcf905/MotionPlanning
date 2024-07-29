using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MotionPlanning.State;

namespace MotionPlanning.Statements
{
    public abstract class Statement : IURScript
    {
        public Statement(string gcode) 
        {
            this.GCode = gcode;
        }

        public string GCode { get; set; }
        public char CommandType { get; set; }
        public int CommandNumber { get; set; }
        public bool Valid { get; set; }
        public abstract string URScript(State.State st);
    }
}
