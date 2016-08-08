using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class Variable
    {
        public string Symbol { get; private set; }

        public Variable(string symbol)
        {
            this.Symbol = symbol;
        }
    }
}
