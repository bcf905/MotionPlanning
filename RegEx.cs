using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MotionPlanning
{
    public class RegEx
    {
        /// <summary>
        ///	Regular Expression matching string with pattern.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="pattern">A regular expression pattern to match.</param>
        /// <param name="str">A string to test if pattern match.</param>
        /// <returns>Boolean vaule</returns>
        public static bool isMatch(string pattern, string str)
        {
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            return rg.IsMatch(str);
        }
        /// <summary>
        ///	Finds and return a parameter's integer value from a string provided.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="name">A char. The name of the parameter.</param>
        /// <param name="str">A string containing the parameter name and integer value</param>
        /// <returns>Integer value</returns>
        public static int returnInteger(char name, string str)
        {
            int x = int.MinValue;
            string pattern = name + @"(?<value>\d+)";
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            var match = rg.Match(str);
            if (match.Success)
            {
                x = int.Parse(match.Groups["value"].Value);
            }
            return x;
        }
        /// <summary>
        ///	Finds and return a parameter's float value from a string provided.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="name">A char. The name of the parameter.</param>
        /// <param name="str">A string containing the parameter name and float value</param>
        /// <returns>Float value</returns>
        public static float returnFloat(char name, string str)
        {
            float x = float.MinValue;
            string pattern = name + @"(?<value>[0-9]+([.][0-9]+)*)";
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            var match = rg.Match(str);
            if (match.Success)
            {
                x = float.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);
            }
            return x;
        }
    }
}
