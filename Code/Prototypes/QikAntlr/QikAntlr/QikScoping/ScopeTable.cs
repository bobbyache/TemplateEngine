using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikScoping
{
    internal class ScopeTable
    {
        private static Dictionary<string, string> table = new Dictionary<string, string>();

        public static string[] Symbols
        {
            get { return table.Keys.ToArray(); }
        }

        internal static void UpdateSymbol(string symbol, string value = null)
        {
            if (table.ContainsKey(symbol))
            {
                table[symbol] = value;
            }
            else
            {
                table.Add(symbol, value);
            }
        }

        internal static void Clear()
        {
            table.Clear();
        }

        public static string FindValue(string symbol)
        {
            return table[symbol];
        }
    }
}
