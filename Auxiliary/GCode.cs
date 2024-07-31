using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using MotionPlanning.Job;
using MotionPlanning.Statements;

namespace MotionPlanning.Auxiliary
{
    public class GCode
    {
        public static Job.Job Read(StreamReader reader)
        {
            Job.Job job = new();
            string? line;

            while ((line = reader.ReadLine()) != null )
            {
                IURScript statement = Identifier.Identify(line, job);
                job.AddStatement(statement);
            }

            return job;
        }
    }
}
