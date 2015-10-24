using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InSeasonAPI.Utils
{
    public static class TypeConvert
    {
        public static int StrToIntDef(string s, int @default)
        {
            int number;
            if (int.TryParse(s, out number))
                return number;
            return @default;
        }
    }
}