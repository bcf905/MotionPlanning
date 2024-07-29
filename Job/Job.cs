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
            st = new State.State();
            statements = new List<IURScript>();
        }
        public void AddStatement(IURScript statement)
        {
            statements.Add(statement);
        }
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

    }
}
