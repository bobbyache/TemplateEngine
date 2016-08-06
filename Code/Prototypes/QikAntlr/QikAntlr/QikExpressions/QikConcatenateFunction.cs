using CygSoft.Qik.LanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikExpressions
{
    public class QikConcatenateFunction : QikFunction
    {
        private List<QikFunction> functions = new List<QikFunction>();

        private ScopeTable scopeTable;

        internal QikConcatenateFunction(ScopeTable scopeTable) : base(scopeTable)
        {
            this.InputType = QikChildInputTypeEnum.Concatenation;
            this.scopeTable = scopeTable;
        }

        public override string Execute()
        {
            string result = "";
            foreach (QikFunction func in functions)
            {
                result += func.Execute();
            }
            return result;
        }

        public void AddFunction(QikFunction func)
        {
            functions.Add(func);
        }
    }
}
