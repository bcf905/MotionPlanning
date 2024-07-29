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
    }
}
