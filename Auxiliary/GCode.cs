using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using MotionPlanning.Job;
using MotionPlanning.Statements;
using MotionPlanning.Workspace;

namespace MotionPlanning.Auxiliary
{
    /// <summary>
    ///	Auxiliary functions to handle G-Code
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>Void</returns>
    public class GCode
    {
        /// <summary>
        ///	A method that identifies G-Code statements from a streamreader
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="reader">A streamreader connection to a G-Code file</param>
        /// <returns>A Job object with all the statements included</returns>
        public static Job.Job Read(StreamReader reader, Workspace.Workspace workspace)
        {
            Job.Job job = new(workspace);
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
