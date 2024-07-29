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
        string URScript(State.State st);
        bool Valid { get; set; }
        string GCode { get; set; }
        char CommandType { get; set; }
        int CommandNumber { get; set; }
    }
}
