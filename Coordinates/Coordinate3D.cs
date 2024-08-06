using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Coordinates
{
    public class Coordinate3D
    {
        /// <summary>
        ///	A container for a 3 dimensional coordinate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="x">The coordinate's x value</param>
        /// <param name="y">The coordinate's y value</param>
        /// <param name="z">The coordinate's z value</param>
        /// <returns>Void</returns>
        public Coordinate3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        // X value of the coordinate
        public float X { get; set; }

        // Y value of the coordinate
        public float Y { get; set; }

        // Z value of the coordinate
        public float Z { get; set; }
    }
}
