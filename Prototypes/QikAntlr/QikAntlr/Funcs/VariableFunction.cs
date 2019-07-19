using CygSoft.Qik.LanguageEngine.Infrastructure;
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

        public VariableFunction(FuncInfo funcInfo, GlobalTable scopeTable, string symbol)
            : base(funcInfo, scopeTable)
        {
            this.symbol = symbol;
        }

        public override string Execute(IErrorReport errorReport)
        {
            string result = base.scopeTable.GetValueOfSymbol(this.symbol);
            //string result = null;
            //try
            //{
            //    result = base.scopeTable.GetValueOfSymbol(this.symbol);
            //    if (result == null)
            //        errorReport.AddError(new CustomError(this.Line, this.Column, string.Format("Variable {0} returned null", symbol), this.Name));
            //}
            //catch (Exception)
            //{
            //    errorReport.AddError(new CustomError(this.Line, this.Column, string.Format("Variable {0} returned null", symbol), this.Name));
            //}
            return result;
        }
    }
}
