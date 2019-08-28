using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Base.Core
{
    public static class StringHelper
    {
        /// <summary>
        /// Return true if null or empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Trim or return null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimToNull(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            str = str.Trim();

            if (str.Length == 0)
                return null;
            return str;
        }

        /// <summary>
        /// Trim or return empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimToEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return String.Empty;
            return str.Trim();
        }
    }
}
