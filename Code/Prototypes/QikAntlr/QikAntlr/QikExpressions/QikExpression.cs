using QikLanguageEngine.QikScoping;
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
        public string Title { get; private set; }


        public QikExpression(string symbol, string title, QikFunction func)
        {
            this.Symbol = symbol;
            this.func = func;
            this.Title = title;
            ScopeTable.UpdateSymbol(symbol);
        }

        public string Execute()
        {
            string newValue = this.func.Execute();
            ScopeTable.UpdateSymbol(this.Symbol, newValue);
            return newValue;
        }
    }
}
