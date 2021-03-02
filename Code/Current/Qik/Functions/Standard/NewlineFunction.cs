using System;

namespace CygSoft.Qik.Functions
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
