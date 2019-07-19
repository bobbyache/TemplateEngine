using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.LanguageEngine.Functions.Core
{
    public class ReplaceFunction : BaseFunction
    {
        public ReplaceFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, List<IFunction> functionArguments)
            : base(funcInfo, scopeTable, functionArguments)
        {

        }

        public override string Execute(IErrorReport errorReport)
        {
            if (functionArguments.Count() != 3)
                errorReport.AddError(new CustomError(this.Line, this.Column, "Too many arguments", this.Name));

            string result = null;
            try
            {
                List<string> textResults = new List<string>();
                foreach (BaseFunction funcArg in functionArguments)
                {
                    textResults.Add(funcArg.Execute(errorReport));
                }

                string targetText = functionArguments[0].Execute(errorReport);
                string textToReplace = functionArguments[1].Execute(errorReport);
                string replacementText = functionArguments[2].Execute(errorReport);

                if (targetText != null && targetText.Length >= 1)
                {
                    result = targetText.Replace(textToReplace, replacementText);
                }
            }
            catch (Exception)
            {
                errorReport.AddError(new CustomError(this.Line, this.Column, "Bad function call.", this.Name));
            }
            return result;
        }
    }
}
