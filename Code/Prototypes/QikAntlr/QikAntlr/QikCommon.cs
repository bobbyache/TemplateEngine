using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine
{
    internal class QikCommon
    {
        public static string StripOuterQuotes(string text)
        {
            if (text != null && text.Length >= 2)
            {
                if (text.Substring(0, 1) == "\"" && text.Substring(text.Length - 1, 1) == "\"")
                {
                    if (text.Length != 0)
                        return text.Substring(1, text.Length - 2);
                }
            }

            return text;
        }
    }
}
