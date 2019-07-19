using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class TextFunction : BaseFunction
    {
        private readonly string text;

        internal TextFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string text) : base(funcInfo, scopeTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return this.text;
        }
    }
}
