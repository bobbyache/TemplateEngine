using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class IndentFunction : BaseFunction
    {
        public IndentFunction(GlobalTable scopeTable, List<BaseFunction> functionArguments)
            : base(scopeTable, functionArguments)
        {
        }

        public override string Execute()
        {
            if (functionArguments.Count() != 3)
                throw new ApplicationException("Too many arguments.");

            string txt = functionArguments[0].Execute();
            string indentType = functionArguments[1].Execute();
            int noOfTimes = int.Parse(functionArguments[2].Execute());

            string indentedText = "";

            if (txt != null && txt.Length >= 1)
            {
                if (indentType == "TAB")
                    indentedText = txt.PadLeft(txt.Length + noOfTimes, '\t');
                else // SPACE
                    indentedText = txt.PadLeft(txt.Length + noOfTimes, ' ');

                return indentedText;
            }
            return txt;
        }
    }
}
