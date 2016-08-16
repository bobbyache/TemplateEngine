using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class VariableFunction : BaseFunction
    {
        private string symbol;

        public VariableFunction(GlobalTable scopeTable, string symbol) : base(scopeTable)
        {
            this.symbol = symbol;
        }

        public override string Execute()
        {
            return base.scopeTable.GetValueOfSymbol(this.symbol);
        }
    }
}
