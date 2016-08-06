using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikScoping
{
    public class ScopeItem
    {
        public string Title { get; private set; }
        public string Placeholder { get; private set; }
        public string Symbol { get; private set; }
        public string Value { get; set; }

        public ScopeItem(string title, string symbol, string value = null)
        {
            this.Title = title;
            this.Symbol = symbol;
            this.Value = value;
            this.Placeholder = "@{" + symbol.Substring(1, symbol.Length - 1) + "}";
        }
    }
}
