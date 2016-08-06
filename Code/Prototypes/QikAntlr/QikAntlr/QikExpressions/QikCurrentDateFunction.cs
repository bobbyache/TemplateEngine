using QikLanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikCurrentDateFunction : QikFunction
    {
        internal QikCurrentDateFunction(ScopeTable scopeTable, QikFunction func)
            : base(scopeTable, func)
        {

        }

        internal QikCurrentDateFunction(ScopeTable scopeTable, QikLiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal QikCurrentDateFunction(ScopeTable scopeTable, QikVariable variable)
            : base(scopeTable, variable)
        {

        }

        public override string Execute()
        {
            string dateFormatText = base.Execute();

            if (dateFormatText != null && dateFormatText.Length >= 1)
            {
                string dateText = DateTime.Now.ToString(dateFormatText);
                return dateText;
            }
            return "";
        }
    }
}
