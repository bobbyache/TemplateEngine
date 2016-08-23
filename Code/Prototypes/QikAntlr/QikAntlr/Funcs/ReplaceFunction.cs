using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class ReplaceFunction : BaseFunction
    {
        public ReplaceFunction(GlobalTable scopeTable, List<BaseFunction> functionArguments)
            : base(scopeTable, functionArguments)
        {

        }

        public override string Execute()
        {
            if (functionArguments.Count() != 3)
                throw new ApplicationException("Invalid number of arguments.");

            List<string> textResults = new List<string>();
            foreach (BaseFunction funcArg in functionArguments)
            {
                textResults.Add(funcArg.Execute());
            }

            string targetText = functionArguments[0].Execute();
            string textToReplace = functionArguments[1].Execute();
            string replacementText = functionArguments[2].Execute();

            if (targetText != null && targetText.Length >= 1)
            {
                return targetText.Replace(textToReplace, replacementText);
            }
            return targetText;
        }
    }
}
