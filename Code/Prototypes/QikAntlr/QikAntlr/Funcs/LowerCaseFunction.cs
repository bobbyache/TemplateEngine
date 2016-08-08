using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class LowerCaseFunction : BaseFunction
    {
        internal LowerCaseFunction(GlobalTable scopeTable, BaseFunction func)
            : base(scopeTable, func)
        {

        }

        internal LowerCaseFunction(GlobalTable scopeTable, LiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal LowerCaseFunction(GlobalTable scopeTable, Variable variable)
            : base(scopeTable, variable)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();
            if (txt != null && txt.Length >= 1)
            {
                return txt.ToLower();
            }
            return txt;
        }
    }
}
