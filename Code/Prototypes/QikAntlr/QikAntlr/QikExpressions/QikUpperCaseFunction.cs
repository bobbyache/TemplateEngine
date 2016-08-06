using CygSoft.Qik.LanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikExpressions
{
    public class QikUpperCaseFunction : QikFunction
    {
        internal QikUpperCaseFunction(ScopeTable scopeTable, QikFunction func)
            : base(scopeTable, func)
        {

        }

        internal QikUpperCaseFunction(ScopeTable scopeTable, QikLiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal QikUpperCaseFunction(ScopeTable scopeTable, QikVariable variable)
            : base(scopeTable, variable)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();
            if (txt != null && txt.Length >= 1)
            {
                return txt.ToUpper();
            }
            return txt;
        }
    }
}
