using CygSoft.Qik.LanguageEngine.FunctionPlugins;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class VariableFunction : BaseFunction
    {
        private readonly string symbol;

        public VariableFunction(IFuncInfo funcInfo, GlobalTable scopeTable, string symbol)
            : base(funcInfo, scopeTable)
        {
            this.symbol = symbol;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return base.scopeTable.GetValueOfSymbol(this.symbol);
        }
    }
}
