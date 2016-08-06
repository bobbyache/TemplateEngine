using QikLanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikCamelCaseFunction : QikFunction
    {
        internal QikCamelCaseFunction(ScopeTable scopeTable, QikFunction func)
            : base(scopeTable, func)
        {

        }

        internal QikCamelCaseFunction(ScopeTable scopeTable, QikLiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal QikCamelCaseFunction(ScopeTable scopeTable, QikVariable variable)
            : base(scopeTable, variable)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();

            if (txt != null && txt.Length >= 1)
            {
                string firstChar = txt.Substring(0, 1);
                string theRest = txt.Substring(1, txt.Length - 1);
                return firstChar.ToLower() + theRest;
            }
            return txt;
        }
    }
}
