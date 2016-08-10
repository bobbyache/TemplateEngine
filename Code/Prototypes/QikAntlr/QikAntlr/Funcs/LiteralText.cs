using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class LiteralText
    {
        public string Value { get; private set; }

        public LiteralText(string value)
        {
            this.Value = Common.StripOuterQuotes(value);
        }
    }
}
