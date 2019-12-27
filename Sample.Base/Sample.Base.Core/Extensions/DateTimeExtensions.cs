using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Base.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToFormat12h(this DateTime? dt)
        {
            return dt == null ? "" : Convert.ToDateTime(dt).ToString("yyyy/MM/dd hh:mm:ss tt");
        }
    }
}
