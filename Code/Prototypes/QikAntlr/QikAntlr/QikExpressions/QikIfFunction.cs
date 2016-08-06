using CygSoft.Qik.LanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikExpressions
{
    public class QikIfFunction : QikFunction
    {
        private Dictionary<string, QikFunction> functions = new Dictionary<string, QikFunction>();
        private List<string> options = new List<string>();

        private string symbol = null;
        private ScopeTable scopeTable;

        internal QikIfFunction(ScopeTable scopeTable, string symbol) : base (scopeTable)
        {
            this.symbol = symbol;
            this.InputType = QikChildInputTypeEnum.IfStatement;
            this.scopeTable = scopeTable;
        }

        public override string Execute()
        {
            string curOption = scopeTable.FindSymbol(this.symbol);
            if (curOption != null && functions.ContainsKey(curOption))
            {
                QikFunction func = functions[curOption];
                string result = func.Execute();

                return result;
            }
            return null;
        }

        public void AddFunction(string text, QikFunction func)
        {
            functions.Add(QikCommon.StripOuterQuotes(text), func);
        }
    }
}
