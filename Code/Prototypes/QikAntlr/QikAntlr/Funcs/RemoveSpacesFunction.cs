using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class RemoveSpacesFunction : BaseFunction
    {
        internal RemoveSpacesFunction(GlobalTable scopeTable, BaseFunction func)
            : base(scopeTable, func)
        {

        }

        internal RemoveSpacesFunction(GlobalTable scopeTable, LiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal RemoveSpacesFunction(GlobalTable scopeTable, Variable variable)
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
