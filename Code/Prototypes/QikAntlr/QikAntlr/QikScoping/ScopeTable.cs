using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikScoping
{
    internal class ScopeTable
    {
        private Dictionary<string, ScopeItem> table = new Dictionary<string, ScopeItem>();

        public string[] Symbols
        {
            get 
            {
                if (table.Keys.Select(r => r).Any())
                    return table.Keys.Select(r => r).ToArray();
                else
                    return new string[0];
            }
        }

        public string[] Placeholders
        {
            get 
            {
                if (table.Values.Select(r => r.Placeholder).Any())
                    return table.Values.Select(r => r.Placeholder).ToArray();
                else
                    return new string[0];
            }
        }

        internal void UpdateSymbol(string title, string symbol, string value = null)
        {
            if (table.ContainsKey(symbol))
            {
                table[symbol].Value = value;
            }
            else
            {
                table.Add(symbol, new ScopeItem(title, symbol, value));
            }
        }

        internal void Clear()
        {
            table.Clear();
        }

        public string FindSymbol(string symbol)
        {
            return table[symbol].Value;
        }

        public string FindPlaceholder(string placeholder)
        {
            return table.Where(r => r.Value.Placeholder == placeholder).SingleOrDefault().Value.Value;
        }

        public string FindTitle(string placeholder)
        {
            return table.Where(r => r.Value.Placeholder == placeholder).SingleOrDefault().Value.Title;
        }
    }
}
