using System;

namespace CygSoft.Qik.Functions
{
    public class NewlineFunction : BaseFunction
    {
        public NewlineFunction(IFuncInfo funcInfo, IGlobalTable scopeTable)
            : base(funcInfo, scopeTable)
        {
        }

        public override string Execute(IErrorReport errorReport)
        {
            return Environment.NewLine;
        }
    }
}
