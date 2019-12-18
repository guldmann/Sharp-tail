using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class TabPageHelper
    {
        private const string CloseCross = "    [X]   ";
        private static readonly int length = 30;


        /// <summary>
        /// Truncate filename to 30 and add close cross
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string Truncate(this string file)
        {
            StringBuilder sb = new StringBuilder();

            var index = file.LastIndexOf("\\") + 1;
            var substring = file.Substring(index);
            var cut = 0;
            
            if (substring.Length > length)
            {
                cut = substring.Length - length;
            }

            return sb.Append("...").Append(substring.Substring(cut)).Append(CloseCross).ToString();
        }
    }
}
