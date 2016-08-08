using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    internal abstract class InputSymbol : BaseSymbol
    {
        public string DefaultValue { get; private set; }

        public InputSymbol(string symbol, string title, string defaultValue) : base(symbol, title)
        {
            this.DefaultValue = QikCommon.StripOuterQuotes(defaultValue);
        }

        public InputSymbol(string symbol, string title, string defaultValue, string prefix, string postfix)
            : base(symbol, title, prefix, postfix)
        {
            this.DefaultValue = defaultValue;
        }
    }
}
