using QikLanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikTextFunction : QikFunction
    {
        internal QikTextFunction(ScopeTable scopeTable, QikFunction func)
            : base(scopeTable, func)
        {

        }

        internal QikTextFunction(ScopeTable scopeTable, QikLiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal QikTextFunction(ScopeTable scopeTable, QikVariable variable)
            : base(scopeTable, variable)
        {

        }

        public override string Execute()
        {
            return base.Execute();
        }
    }
}
