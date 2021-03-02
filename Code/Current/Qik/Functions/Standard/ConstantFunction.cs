using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.Functions
{
    public class ConstantFunction : BaseFunction
    {
        private readonly string text;

        public ConstantFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string text)
            : base(funcInfo, scopeTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport) => text;
    }
}
