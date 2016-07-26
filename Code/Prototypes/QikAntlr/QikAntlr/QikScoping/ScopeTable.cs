using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikScoping
{
    internal class ScopeTable
    {
        private static Dictionary<string, ScopeItem> table = new Dictionary<string, ScopeItem>();

        public static string[] Symbols
        {
            get { return table.Keys.ToArray(); }
        }

        public static string[] Placeholders
        {
            get { return table.Values.Select(r => r.Placeholder).ToArray(); }
        }

        internal static void UpdateSymbol(string title, string symbol, string value = null)
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

        internal static void Clear()
        {
            table.Clear();
        }

        public static string FindSymbol(string symbol)
        {
            return table[symbol].Value;
        }

        public static string FindPlaceholder(string placeholder)
        {
            return table.Where(r => r.Value.Placeholder == placeholder).SingleOrDefault().Value.Value;
        }

        public static string FindTitle(string placeholder)
        {
            return table.Where(r => r.Value.Placeholder == placeholder).SingleOrDefault().Value.Title;
        }
    }
}
