using QikLanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikIfFunction : QikFunction
    {
        private Dictionary<string, QikFunction> functions = new Dictionary<string, QikFunction>();
        private List<string> options = new List<string>();

        private string symbol = null;

        public QikIfFunction(string symbol)
        {
            this.symbol = symbol;
            this.InputType = QikChildInputTypeEnum.IfStatement;
        }

        public override string Execute()
        {
            string curOption = ScopeTable.FindValue(this.symbol);
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
            functions.Add(StripOuterQuotes(text), func);
        }

        private string StripOuterQuotes(string text)
        {
            if (text.Length != 0)
                return text.Substring(1, text.Length - 2);
            return text;
        }
    }
}
