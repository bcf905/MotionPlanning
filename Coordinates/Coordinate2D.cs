using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Coordinates
{
    public class Coordinate2D
    {
        /// <summary>
        ///	A container for a 2 dimensional coordinate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="x">The coordinates x value</param>
        /// <param name="y">The coordinates y value</param>
        /// <returns>Void</returns>
        public Coordinate2D(float x, float y) 
        {
            this.X = x; 
            this.Y = y;
        }

        /// <summary>
        ///	A method to return the coordinates as a tuple
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>A tuple (float x, float y)</returns>
        public (float, float) GetCoordinate()
        {
            return (this.X, this.Y);
        }

        // X value of the coordinate
        public float X { get; set; }

        // Y value of the coordinate
        public float Y { get; set; }

    }
}
