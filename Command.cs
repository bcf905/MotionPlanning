using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning
{

    public enum CommandType
    {
        None,
        RapidMove,              // G0
        LinearMove,             // G1
        Dwell,                  // G4
        Inches,                 // G20
        Millimeters,            // G21
        Home,                   // G28
        Leveling,               // G29
        AbsolutePositioning,    // G90
        RelativePositioning,    // G91
        SetCurrentPosition,     // G92
    }
    public struct Command
    {
        public CommandType Type;
        public char GCodeType;
        public int GCodeNumber;
    }


}
