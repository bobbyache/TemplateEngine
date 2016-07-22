using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikVariable
    {
        public string Symbol { get; private set; }

        public QikVariable(string symbol)
        {
            this.Symbol = symbol;
        }
    }
}
