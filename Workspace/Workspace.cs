using System;
using System.Collections.Generic;
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
        public Workspace(Coordinate2D coord1, Coordinate2D cord2, float height) 
        {
            this.SetArea(coord1, cord2);
            this.Height = height;
        }

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
        public float LowerX {  get; set; }
        public float LowerY { get; set; }
        public float UpperX { get; set; }
        public float UpperY { get; set; }
        public float Height { get; set; }
        public bool IsJobValid(Job.Job job) 
        {
            if ((job.MaxX - job.MinX) > (this.UpperX - this.LowerX)) { return false; }
            if ((job.MaxY - job.MinY) > (this.UpperY - this.LowerY)) { return false; }
            if ((job.MaxZ - job.MinZ) > this.Height) { return false; }
            return true;
        }
        public void CalibrateJob(Job.Job job)
        {
            // Calculating the center of workspace
            float deltaWorkspaceX = this.UpperX - this.LowerX;
            float deltaWorkspaceY = this.UpperY - this.LowerY;
            float centerWorkspaceX = deltaWorkspaceX / 2f;
            float centerWorkspaceY = deltaWorkspaceY / 2f;

            // Calculating the center of job
            float deltaJobX = job.MaxX - job.MinX;
            float deltaJobY = job.MaxY - job.MinY;
            float centerJobX = deltaJobX / 2f;
            float centerJobY = deltaJobY / 2f;

            // Calculating shiftment
            job.XShift = centerWorkspaceX - (centerJobX + job.MinX);
            job.YShift = centerWorkspaceY - (centerJobY + job.MinY);
            job.ZShift = 0 - job.MinZ;
        }
    }
}
