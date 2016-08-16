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
        public CamelCaseFunction(GlobalTable scopeTable, List<BaseFunction> functionArguments) : base(scopeTable, functionArguments)
        {

        }

        public override string Execute()
        {
            if (functionArguments.Count() != 1)
                throw new ApplicationException("Too many arguments.");

            string txt = functionArguments[0].Execute();

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
