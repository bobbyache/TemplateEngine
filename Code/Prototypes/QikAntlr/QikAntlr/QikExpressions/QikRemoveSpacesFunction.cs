using QikLanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikRemoveSpacesFunction : QikFunction
    {
        internal QikRemoveSpacesFunction(ScopeTable scopeTable, QikFunction func)
            : base(scopeTable, func)
        {

        }

        internal QikRemoveSpacesFunction(ScopeTable scopeTable, QikLiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal QikRemoveSpacesFunction(ScopeTable scopeTable, QikVariable variable)
            : base(scopeTable, variable)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();
            if (txt != null && txt.Length >= 1)
            {
                return txt.Replace(" ", "");
            }
            return txt;
        }
    }
}
