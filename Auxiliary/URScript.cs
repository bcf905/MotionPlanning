using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPlanning.Auxiliary
{
    public class URScript
    {
        public static string CreateScript(Job.Job job)
        {
            string script = "def test_workspace():\n";
            foreach (string statement in job.GetURScript())
            {
                script += $"   {statement}\n";
            }
            script += "end\n";
            return script;

        }
    }
}
