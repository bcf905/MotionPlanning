using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Auxiliary
{
    /// <summary>
    ///	Auxiliary functions to convert values
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>Void</returns>
    public class Convert
    {
        /// <summary>
        ///	A method that converts inch values to millimeter values
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="inch">A value meassured in inches</param>
        /// <returns>A value meassured in millimeters</returns>
        public static float InchesToMillimeter(float inch)
        {
            float factor = 25.4f;
            return inch * factor;
        }

        /// <summary>
        ///	A method that converts millisecond values to second values
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="ms">A value meassured in milliseconds</param>
        /// <returns>A value meassured in seconds</returns>
        public static float MillisecondsToSeconds(float ms)
        {
            float factor = 1000.0f;
            return ms * factor;
        }

        /// <summary>
        ///	A method that converts feedrate to the time it takes to travel the distance
        ///	Used to override the velocity of UR5e
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="feedrate">Printers travel distance (mm) in 1 minute</param>
        /// <param name="distance">Distance the UR5e has to move</param>
        /// <returns>The seconds it takes to travel the distance.</returns>
        public static double FeedrateToTime(float feedrate, double distance)
        {
            return distance / (feedrate / 60f);
        }
    }
}
