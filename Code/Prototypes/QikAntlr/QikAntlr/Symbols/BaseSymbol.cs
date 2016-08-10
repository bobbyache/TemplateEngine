using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    internal abstract class BaseSymbol : ISymbol 
    {
        private string prefix = "@{";
        private string postfix = "}";

        public string Title { get; private set; }
        public string Symbol { get; private set; }

        public abstract string Value { get; }

        public string Placeholder
        {
            get
            {
                if (this.Symbol != null)
                    return prefix + this.Symbol.Substring(1, this.Symbol.Length - 1) + postfix;
                else
                    return null;
            }
        }

        public BaseSymbol(string symbol, string title)
        {
            this.Symbol = symbol;
            this.Title = title;
        }

        public BaseSymbol(string symbol, string title, string prefix, string postfix)
        {
            this.prefix = prefix;
            this.postfix = postfix;

            this.Symbol = symbol;
            this.Title = title;
        }
    }
}
