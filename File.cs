using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MotionPlanning
{
    class File
    {
        public static string readGCode(ref StreamReader sr)
        {
            (char, int) g0 = ('G', 0);
            (char, int) g1 = ('G', 1);
            (char, int) g4 = ('G', 4);
            (char, int) g20 = ('G', 20);
            (char, int) g21 = ('G', 21);
            (char, int) g28 = ('G', 28);
            (char, int) g29 = ('G', 29);
            (char, int) g90 = ('G', 90);
            (char, int) g91 = ('G', 91);
            (char, int) g92 = ('G', 92);

            (char, int)[] commands = {g0, g1, g4, g20, g21, g28, g29, g90, g91, g92};

            string[] result = { };

            string line;
            try
            {
                line = sr.ReadLine();

                while (line != null)
                {
                    line = sr.ReadLine();

                    foreach ((char, int) cmd in commands)
                    {
                        string pattern = @"\A\" + cmd.Item1 + @" \d+ ";
                    }
                }

                sr.Close();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
