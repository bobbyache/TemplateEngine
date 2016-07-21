using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikExpression
    {
        private QikFunction func = null;
        public string Symbol { get; private set; }


        public QikExpression(string symbol, QikFunction func)
        {
            this.Symbol = symbol;
            this.func = func;
        }

        public string Execute()
        {
            return this.func.Execute();
        }
    }
}
