using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Functions.Core
{
    public class TextFunction : BaseFunction
    {
        private readonly string text;

        public TextFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string text) : base(funcInfo, scopeTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return this.text;
        }
    }
}
