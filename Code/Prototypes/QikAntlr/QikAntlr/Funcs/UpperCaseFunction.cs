using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class UpperCaseFunction : BaseFunction
    {
        internal UpperCaseFunction(GlobalTable scopeTable, BaseFunction func)
            : base(scopeTable, func)
        {

        }

        internal UpperCaseFunction(GlobalTable scopeTable, LiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal UpperCaseFunction(GlobalTable scopeTable, Variable variable)
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
