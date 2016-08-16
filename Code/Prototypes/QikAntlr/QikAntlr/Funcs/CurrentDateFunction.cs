using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class CurrentDateFunction : BaseFunction
    {
        internal CurrentDateFunction(GlobalTable scopeTable, List<BaseFunction> functionArguments)
            : base(scopeTable, functionArguments)
        {

        }

        public override string Execute()
        {
            if (functionArguments.Count() != 1)
                throw new ApplicationException("Too many arguments.");

            string dateFormatText = functionArguments[0].Execute();

            if (dateFormatText != null && dateFormatText.Length >= 1)
            {
                string dateText = DateTime.Now.ToString(dateFormatText);
                return dateText;
            }
            return "";
        }
    }
}
