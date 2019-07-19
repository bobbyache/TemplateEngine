using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class IfDecissionFunction : BaseFunction
    {
        private readonly Dictionary<string, BaseFunction> functions = new Dictionary<string, BaseFunction>();
        private readonly List<string> options = new List<string>();

        private readonly string symbol = null;

        internal IfDecissionFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string symbol)
            : base(funcInfo, scopeTable)
        {
            this.symbol = symbol;
            this.scopeTable = scopeTable;
        }

        public override string Execute(IErrorReport errorReport)
        {
            string result = null;
            try
            {
                string curOption = scopeTable.GetValueOfSymbol(this.symbol);
                if (curOption != null && functions.ContainsKey(curOption))
                {
                    BaseFunction func = functions[curOption];
                    string txt = func.Execute(errorReport);

                    result = txt;
                }
            }
            catch (Exception)
            {
                errorReport.AddError(new CustomError(this.Line, this.Column, "If statement failed.", this.Name));
            }
            return result;
        }

        public void AddFunction(string text, BaseFunction func)
        {
            functions.Add(Common.StripOuterQuotes(text), func);
        }
    }
}
