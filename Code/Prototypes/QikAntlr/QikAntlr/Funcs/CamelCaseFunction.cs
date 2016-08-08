using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class CamelCaseFunction : BaseFunction
    {
        internal CamelCaseFunction(GlobalTable scopeTable, 
            BaseFunction func)
            : base(scopeTable, func)
        {

        }

        internal CamelCaseFunction(GlobalTable scopeTable, LiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal CamelCaseFunction(GlobalTable scopeTable, Variable variable)
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
