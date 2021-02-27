using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;

namespace CygSoft.Qik.LanguageEngine.Functions.Core
{
    public class IfDecissionFunction : BaseFunction
    {
        private readonly Dictionary<string, IFunction> functions = new Dictionary<string, IFunction>();
        private readonly List<string> options = new List<string>();

        private readonly string symbol = null;

        public IfDecissionFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string symbol)
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
                    IFunction func = functions[curOption];
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

        public void AddFunction(string text, IFunction func)
        {
            functions.Add(StripOuterQuotes(text), func);
        }

        private string StripOuterQuotes(string text)
        {
            if (text != null && text.Length >= 2)
            {
                if (text.Substring(0, 1) == "\"" && text.Substring(text.Length - 1, 1) == "\"")
                {
                    if (text.Length != 0)
                        return text.Substring(1, text.Length - 2);
                }
            }

            return text;
        }
    }
}
