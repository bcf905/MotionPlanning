using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Statements;
using MotionPlanning.State;

namespace MotionPlanning.Job
{
    public class Job
    {
        List<IURScript> statements;
        State.State st;
        
        public Job() 
        {
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
            statements = new List<IURScript>();
        }
        public void AddStatement(IURScript statement)
        {
            statements.Add(statement);
        }
        public State.State GetState() { return  st; }

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
        private void setMinX(float x)
        {
            if(x != float.MinValue)
            {
                if (this.MinX > x) { this.MinX = x; }
            }
        }
        private void setMaxX(float x)
        {
            if (x != float.MinValue)
            {
                if (this.MaxX < x) { this.MaxX = x; }
            }
        }
        private void setMinY(float y)
        {
            if (y != float.MinValue)
            {
                if (this.MinY > y) { this.MinY = y; }
            }
        }
        private void setMaxY(float y)
        {
            if (y != float.MinValue)
            {
                if (this.MaxY < y) { this.MaxY = y; }
            }
        }
        private void setMinZ(float z)
        {
            if (z != float.MinValue)
            {
                if (this.MinZ > z) { this.MinZ = z; }
            }
        }
        private void setMaxZ(float z)
        {
            if (z != float.MinValue)
            {
                if (this.MaxZ < z) { this.MaxZ = z; }
            }
        }
        public void setBounds(float x, float y, float z)
        {
            this.setMinX(x);
            this.setMaxX(x);
            this.setMinY(y);
            this.setMaxY(y);
            this.setMinZ(z);
            this.setMaxZ(z);
        }
        public float MinX { get; set; }
        public float MaxX { get; set; }
        public float MinY { get; set; }
        public float MaxY { get; set; }
        public float MinZ { get; set; }
        public float MaxZ { get; set; }
        public float XShift { get; set; }
        public float YShift { get; set; }
        public float ZShift { get; set; }

    }
}
