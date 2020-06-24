using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class StringExtensions
    {
        public static bool ContainsStringComparison(this string source, string valueSearch,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return source.IndexOf(valueSearch, stringComparison) >= 0;
        }
    }
}
