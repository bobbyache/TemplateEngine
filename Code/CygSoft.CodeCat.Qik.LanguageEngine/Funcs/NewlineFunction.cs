using CygSoft.Qik.LanguageEngine.FunctionPlugins;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class NewlineFunction : BaseFunction
    {
        internal NewlineFunction(FuncInfo funcInfo)
            : base(funcInfo, null)
        {
        }

        public override string Execute(IErrorReport errorReport)
        {
            return Environment.NewLine;
        }
    }
}
