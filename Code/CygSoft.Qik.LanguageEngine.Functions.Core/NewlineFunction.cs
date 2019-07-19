using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;

namespace CygSoft.Qik.LanguageEngine.Functions.Core
{
    public class NewlineFunction : BaseFunction
    {
        public NewlineFunction(IFuncInfo funcInfo)
            : base(funcInfo, null)
        {
        }

        public override string Execute(IErrorReport errorReport)
        {
            return Environment.NewLine;
        }
    }
}
