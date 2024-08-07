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
        /// <summary>
        ///	A method that creates a URScript function.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="job">A Job object containing the statement</param>
        /// <returns>A string containing the script</returns>
        public static string CreateScript(Job.Job job)
        {
            string script = "def test_workspace():\n";
            foreach (string statement in job.GetURScript())
            {
                // Indentation of at least 3 is a must
                script += $"   {statement}\n";
            }
            script += "end\n";
            return script;

        }
    }
}
