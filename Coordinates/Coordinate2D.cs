using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Coordinates
{
    public class Coordinate2D
    {
        public Coordinate2D(float x, float y) 
        {
            this.X = x; 
            this.Y = y;
        }

        public (float, float) GetCoordinate()
        {
            return (this.X, this.Y);
        }
        float X { get; set; }
        float Y { get; set; }

    }
}
