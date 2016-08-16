using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    internal abstract class InputSymbol : BaseSymbol, IInputField
    {
        public string DefaultValue { get; private set; }

        public InputSymbol(string symbol, string title, string description, string defaultValue, 
            bool isPlaceholder) 
            : base(symbol, title, description, isPlaceholder)
        {
            this.DefaultValue = Common.StripOuterQuotes(defaultValue);
        }

        public InputSymbol(string symbol, string title, string description, string defaultValue, bool isPlaceholder,  
            string prefix, string postfix)
            : base(symbol, title, description, isPlaceholder, prefix, postfix)
        {
            this.DefaultValue = defaultValue;
        }
    }
}
