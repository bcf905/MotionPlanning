using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using MotionPlanning.Coordinates;
using MotionPlanning.Job;

namespace MotionPlanning.Workspace
{
    public class Workspace
    {
        /// <summary>
        ///	A container for the robot's workspace
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="coord1">A 2D coordinate of the corner of the workspace</param>
        /// <param name="coord2">A 2D coordinate of the corner diagonally to coord1 parameter cord</param>
        /// <param name="height">The height of the workspace</param>
        /// <param name="offset">The offset value of z</param>
        /// <returns>Void</returns>
        public Workspace(Coordinate2D coord1, Coordinate2D coord2, float height, float offset) 
        {
            this.SetArea(coord1, coord2);
            this.Height = height;
            this.OffsetZ = offset;
            this.IPAddress = "localhost";
            this.Feedrate = 1000f;
            this.Extrude = 0.5f;
            this.Toolposition = new Coordinate3D(0, 0, 0);
        }

        /// <summary>
        ///	A method to find the lower left and upper right corner
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="coord1">A 2D coordinate of the corner of the workspace</param>
        /// <param name="coord2">A 2D coordinate of the corner diagonally to coord1 parameter cord</param>
        /// <returns>Void</returns>
        private void SetArea(Coordinate2D cord1, Coordinate2D cord2) 
        {
            if (cord1.X < cord2.X)
            {
                this.LowerX = cord1.X;
                this.UpperX = cord2.X;
            }
            else
            {
                this.LowerX = cord2.X;
                this.UpperX = cord1.X;
            }
            if (cord1.Y < cord2.Y)
            {
                this.LowerY = cord1.Y;
                this.UpperY = cord2.Y;
            }
            else
            {
                this.LowerY = cord2.Y;
                this.UpperY = cord1.Y;
            }
        }

        // X value of lower left corner of workspace
        public float LowerX {  get; set; }

        // Y value of lower left corner of workspace
        public float LowerY { get; set; }

        // X value of upper right corner of workspace
        public float UpperX { get; set; }

        // Y value of upper right corner of workspace
        public float UpperY { get; set; }

        // Height of workspace
        public float Height { get; set; }
        public float OffsetZ { get; set; }

        // 3D coordinate for origin of workspace
        public Coordinate3D Origin 
        {
            get
            {
                float x = (this.UpperX - this.LowerX) / 2f;
                float y = (this.UpperY - this.LowerY) / 2f;
                float z = (this.Height - this.OffsetZ) / 2f;
                return new Coordinate3D(x, y, z);
            }
        }

        // 3D coordinate for the low corner 1 of workspace
        public Coordinate3D Corner1Low
        {
            get
            {
                float x = this.LowerX;
                float y = this.LowerY;
                float z = this.OffsetZ;
                return new Coordinate3D(x, y, z);
            }
        }

        // 3D coordinate for the high corner 1 of workspace
        public Coordinate3D Corner1High
        {
            get
            {
                float x = this.LowerX;
                float y = this.LowerY;
                float z = this.Height;
                return new Coordinate3D(x, y, z);
            }
        }

        // 3D coordinate for the low corner 2 of workspace
        public Coordinate3D Corner2Low
        {
            get
            {
                float x = this.LowerX;
                float y = this.UpperY;
                float z = this.OffsetZ;
                return new Coordinate3D(x, y, z);
            }
        }

        // 3D coordinate for the high corner 2 of workspace
        public Coordinate3D Corner2High
        {
            get
            {
                float x = this.LowerX;
                float y = this.UpperY;
                float z = this.Height;
                return new Coordinate3D(x, y, z);
            }
        }
        // 3D coordinate for the low corner 3 of workspace
        public Coordinate3D Corner3Low
        {
            get
            {
                float x = this.UpperX;
                float y = this.UpperY;
                float z = this.OffsetZ;
                return new Coordinate3D(x, y, z);
            }
        }

        // 3D coordinate for the high corner 3 of workspace
        public Coordinate3D Corner3High
        {
            get
            {
                float x = this.UpperX;
                float y = this.UpperY;
                float z = this.Height;
                return new Coordinate3D(x, y, z);
            }
        }

        // 3D coordinate for the low corner 4 of workspace
        public Coordinate3D Corner4Low
        {
            get
            {
                float x = this.UpperX;
                float y = this.LowerY;
                float z = this.OffsetZ;
                return new Coordinate3D(x, y, z);
            }
        }

        // 3D coordinate for the high corner 4 of workspace
        public Coordinate3D Corner4High
        {
            get
            {
                float x = this.UpperX;
                float y = this.LowerY;
                float z = this.Height;
                return new Coordinate3D(x, y, z);
            }
        }

        /// <summary>
        ///	A method that calculate of size of job is not to big for workspace
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="job">A Job object</param>
        /// <returns>Boolean value indicating if job can fit workspace</returns>
        public bool IsJobValid(Job.Job job) 
        {
            if ((job.MaxX - job.MinX) > (this.UpperX - this.LowerX)) { return false; }
            if ((job.MaxY - job.MinY) > (this.UpperY - this.LowerY)) { return false; }
            if ((job.MaxZ - job.MinZ) > this.Height) { return false; }
            return true;
        }

        // UR5e IP Addess
        public string IPAddress { get; set; }
        
        // Feedrate of printer - used to calculate velocity
        public float Feedrate { get; set; }

        // Amount of extrusion - value between 0 and 1
        public float Extrude { get; set; }

        public Coordinate3D Toolposition { get; set; }


        public string GetToolposition()
        {
            string tp = $"{this.Toolposition.X},{this.Toolposition.Y},{this.Toolposition.Z}";
            return tp;

        }
        /// <summary>
        ///	A method that returns a URScript to test the bounds of the workspace
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>A string containing the script</returns>

        public string GetTestScript()
        {
            string tooldirection = "0,0,0";

            // origin pose
            string origin = $"p[{this.Origin.X.ToString("f3", CultureInfo.InvariantCulture)},";
            origin += $"{this.Origin.Y.ToString("f3", CultureInfo.InvariantCulture)},";
            origin += $"{this.Origin.Z.ToString("f3", CultureInfo.InvariantCulture)},";
            origin += tooldirection;
            origin += "]";

            // low corner 1 pose
            string corner1low = $"p[{this.Corner1Low.X.ToString("f3", CultureInfo.InvariantCulture)},";
            corner1low += $"{this.Corner1Low.Y.ToString("f3", CultureInfo.InvariantCulture)},";
            corner1low += $"{this.Corner1Low.Z.ToString("f3", CultureInfo.InvariantCulture)},";
            corner1low += tooldirection;
            corner1low += "]";

            // high corner 1 pose
            string corner1high = $"p[{this.Corner1High.X.ToString("f3", CultureInfo.InvariantCulture)},";
            corner1high += $"{this.Corner1High.Y.ToString("f3", CultureInfo.InvariantCulture)},";
            corner1high += $"{this.Corner1High.Z.ToString("f3", CultureInfo.InvariantCulture)},";
            corner1high += tooldirection;
            corner1high += "]";

            // low corner 2 pose
            string corner2low = $"p[{this.Corner2Low.X.ToString("f3", CultureInfo.InvariantCulture)},";
            corner2low += $"{this.Corner2Low.Y.ToString("f3", CultureInfo.InvariantCulture)},";
            corner2low += $"{this.Corner2Low.Z.ToString("f3", CultureInfo.InvariantCulture)},";
            corner2low += tooldirection;
            corner2low += "]";

            // high corner 2 pose
            string corner2high = $"p[{this.Corner2High.X.ToString("f3", CultureInfo.InvariantCulture)},";
            corner2high += $"{this.Corner2High.Y.ToString("f3", CultureInfo.InvariantCulture)},";
            corner2high += $"{this.Corner2High.Z.ToString("f3", CultureInfo.InvariantCulture)},";
            corner2high += tooldirection;
            corner2high += "]";

            // low corner 3 pose
            string corner3low = $"p[{this.Corner3Low.X.ToString("f3", CultureInfo.InvariantCulture)},";
            corner3low += $"{this.Corner3Low.Y.ToString("f3", CultureInfo.InvariantCulture)},";
            corner3low += $"{this.Corner3Low.Z.ToString("f3", CultureInfo.InvariantCulture)},";
            corner3low += tooldirection;
            corner3low += "]";

            // high corner 3 pose
            string corner3high = $"p[{this.Corner3High.X.ToString("f3", CultureInfo.InvariantCulture)},";
            corner3high += $"{this.Corner3High.Y.ToString("f3", CultureInfo.InvariantCulture)},";
            corner3high += $"{this.Corner3High.Z.ToString("f3", CultureInfo.InvariantCulture)},";
            corner3high += tooldirection;
            corner3high += "]";

            // low corner 4 pose
            string corner4low = $"p[{this.Corner4Low.X.ToString("f3", CultureInfo.InvariantCulture)},";
            corner4low += $"{this.Corner4Low.Y.ToString("f3", CultureInfo.InvariantCulture)},";
            corner4low += $"{this.Corner4Low.Z.ToString("f3", CultureInfo.InvariantCulture)},";
            corner4low += tooldirection;
            corner4low += "]";

            // high corner 4 pose
            string corner4high = $"p[{this.Corner4High.X.ToString("f3", CultureInfo.InvariantCulture)},";
            corner4high += $"{this.Corner4High.Y.ToString("f3", CultureInfo.InvariantCulture)},";
            corner4high += $"{this.Corner4High.Z.ToString("f3", CultureInfo.InvariantCulture)},";
            corner4high += tooldirection;
            corner4high += "]";


            string script = "def test_workspace():\n" +
                "   movel(" + origin + ", a=1.2, v=.025)\n" +
                "   movel(" + corner1low + ", a=1.2, v=.025)\n" +
                "   movel(" + corner1high + ", a=1.2, v=.025)\n" +
                "   movel(" + corner2low + ", a=1.2, v=.025)\n" +
                "   movel(" + corner2high + ", a=1.2, v=.025)\n" +
                "   movel(" + corner3low + ", a=1.2, v=.025)\n" +
                "   movel(" + corner3high + ", a=1.2, v=.025)\n" +
                "   movel(" + corner4low + ", a=1.2, v=.025)\n" +
                "   movel(" + corner4high + ", a=1.2, v=.025)\n" +
                "   movel(" + origin + ", a=1.2, v=.025)\n" +
                "end\n";
            return script;
        }
    }
}
