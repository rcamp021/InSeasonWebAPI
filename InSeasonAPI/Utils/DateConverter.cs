using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace InSeasonAPI.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(string input)
        {
            string pattern = "yyyy-MM-dd";
            DateTime parsedDate;
            DateTime.TryParseExact(input, pattern, null,
                DateTimeStyles.None, out parsedDate);
            return parsedDate.AbsoluteEnd();
        }
        private static DateTime AbsoluteStart(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Gets the 11:59:59 instance of a DateTime
        /// </summary>
        private static DateTime AbsoluteEnd(this DateTime dateTime)
        {
            return AbsoluteStart(dateTime).AddDays(1).AddTicks(-1);
        }
    }
}