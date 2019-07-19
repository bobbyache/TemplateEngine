using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Functions.Core
{
    public class FloatFunction : BaseFunction
    {
        private readonly string text;

        public FloatFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string text)
            : base(funcInfo, scopeTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return text;
        }
    }
}
