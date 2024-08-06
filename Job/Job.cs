using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Statements;
using MotionPlanning.State;
using MotionPlanning.Workspace;

namespace MotionPlanning.Job
{
    public class Job
    {
        List<IURScript> statements;
        State.State st;

        /// <summary>
        ///	A container for a job's statements, workspace, state and boundaries
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param workspace="statement">A Workspace object for the current workspace</param>
        /// <returns>Null</returns>
        public Job(Workspace.Workspace workspace) 
        {
            this.wp = workspace;
            this.MinX = float.MaxValue;
            this.MaxX = float.MinValue;
            this.MinY = float.MaxValue;
            this.MaxY = float.MinValue;
            this.MinZ = float.MaxValue;
            this.MaxZ = float.MinValue;
            this.XShift = 0;
            this.YShift = 0;
            this.ZShift = 0;
            st = new State.State();
            st.Workspace = workspace;
            statements = new List<IURScript>();
        }

        /// <summary>
        ///	A method to add statements to a job
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="statement">An IURScript containing a statement</param>
        /// <returns>Void</returns>
        public void AddStatement(IURScript statement)
        {
            statements.Add(statement);
        }

        /// <summary>
        ///	A method to return a job's State object
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="statement">An IURScript containing a statement</param>
        /// <returns>Void</returns>
        public State.State GetState() { return  st; }


        /// <summary>
        ///	A method to return a job's valid statements
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="statement">An IURScript containing a statement</param>
        /// <returns>Void</returns>
        public List<string> GetURScript()
        {
            List<string> result = new List<string>();
            foreach (IURScript statement in statements)
            {
                if (statement.Valid)
                {
                    result.Add(statement.URScript(st));
                }
            }
            return result;
        }

        /// <summary>
        ///	A method to find a job's minimum x value
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="x">x value of current statement</param>
        /// <returns>Void</returns>
        private void setMinX(float x)
        {
            if(x != float.MinValue)
            {
                if (this.MinX > x) { this.MinX = x; }
            }
        }

        /// <summary>
        ///	A method to find a job's maximum x value
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="x">x value of current statement</param>
        /// <returns>Void</returns>
        private void setMaxX(float x)
        {
            if (x != float.MinValue)
            {
                if (this.MaxX < x) { this.MaxX = x; }
            }
        }

        /// <summary>
        ///	A method to find a job's minimum y value
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="y">y value of current statement</param>
        /// <returns>Void</returns>
        private void setMinY(float y)
        {
            if (y != float.MinValue)
            {
                if (this.MinY > y) { this.MinY = y; }
            }
        }

        /// <summary>
        ///	A method to find a job's maximum y value
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="y">y value of current statement</param>
        /// <returns>Void</returns>
        private void setMaxY(float y)
        {
            if (y != float.MinValue)
            {
                if (this.MaxY < y) { this.MaxY = y; }
            }
        }

        /// <summary>
        ///	A method to find a job's minimum z value
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="z">z value of current statement</param>
        /// <returns>Void</returns>
        private void setMinZ(float z)
        {
            if (z != float.MinValue)
            {
                if (this.MinZ > z) { this.MinZ = z; }
            }
        }

        /// <summary>
        ///	A method to find a job's maximum z value
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="z">z value of current statement</param>
        /// <returns>Void</returns>
        private void setMaxZ(float z)
        {
            if (z != float.MinValue)
            {
                if (this.MaxZ < z) { this.MaxZ = z; }
            }
        }

        /// <summary>
        ///	A method to find a job's maximum and minimum coordinates
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="x">x value of current statement</param>
        /// <param name="y">y value of current statement</param>
        /// <param name="z">z value of current statement</param>
        /// <returns>Void</returns>
        public void setBounds(float x, float y, float z)
        {
            this.setMinX(x);
            this.setMaxX(x);
            this.setMinY(y);
            this.setMaxY(y);
            this.setMinZ(z);
            this.setMaxZ(z);
        }

        // A job's minimum X value
        public float MinX { get; set; }

        // A job's maximum X value
        public float MaxX { get; set; }

        // A job's minimum Y value
        public float MinY { get; set; }

        // A job's maximum Y value
        public float MaxY { get; set; }

        // A job's minimum Z value
        public float MinZ { get; set; }

        // A job's maximum Z value
        public float MaxZ { get; set; }

        // Shifting value for X
        // Used to center job in workspace
        public float XShift { get; set; }

        // Shifting value for Y
        // Used to center job in workspace
        public float YShift { get; set; }

        // Shifting value for Z
        // Used to center job in workspace
        public float ZShift { get; set; }

    }
}
