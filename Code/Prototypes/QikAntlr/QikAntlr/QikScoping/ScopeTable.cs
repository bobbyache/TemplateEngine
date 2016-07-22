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

        public static void Add(string symbol, string value = null)
        {
            table.Add(symbol, value);
        }

        public static void Clear()
        {
            table.Clear();
        }

        public static string FindValue(string symbol)
        {
            return table[symbol];
        }
    }
}
