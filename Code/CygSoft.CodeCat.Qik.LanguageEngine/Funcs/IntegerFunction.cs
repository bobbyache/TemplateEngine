using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class IntegerFunction : BaseFunction
    {
        private string text;

        public IntegerFunction(FuncInfo funcInfo, GlobalTable scopeTable, string text)
            : base(funcInfo, scopeTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return this.text;
        }
    }
}
