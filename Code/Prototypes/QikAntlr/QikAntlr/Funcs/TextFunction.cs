using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class TextFunction : BaseFunction
    {
        internal TextFunction(GlobalTable scopeTable, BaseFunction func)
            : base(scopeTable, func)
        {
        }

        internal TextFunction(GlobalTable scopeTable, LiteralText literalText)
            : base(scopeTable, literalText)
        {
        }

        internal TextFunction(GlobalTable scopeTable, Variable variable)
            : base(scopeTable, variable)
        {
        }

        public override string Execute()
        {
            return base.Execute();
        }
    }
}
