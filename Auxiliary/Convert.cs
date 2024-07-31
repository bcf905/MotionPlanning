using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Auxiliary
{
    public class Convert
    {
        public static float InchesToMillimeter(float inch)
        {
            float factor = 25.4f;
            return inch * factor;
        }
        public static float MillisecondsToSeconds(float ms)
        {
            float factor = 1000.0f;
            return ms * factor;
        }
    }
}
