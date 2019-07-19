using CygSoft.Qik.LanguageEngine.FunctionPlugins;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class ConcatenateFunction : BaseFunction
    {
        private readonly List<BaseFunction> functions = new List<BaseFunction>();

        internal ConcatenateFunction(FuncInfo funcInfo, GlobalTable scopeTable)
            : base(funcInfo, scopeTable)
        {
            this.scopeTable = scopeTable;
        }

        public override string Execute(IErrorReport errorReport)
        {
            string result = null;
            try
            {
                foreach (BaseFunction func in functions)
                {
                    result += func.Execute(errorReport);
                }
            }
            catch (Exception)
            {
                errorReport.AddError(new CustomError(this.Line, this.Column, "Concatenation error.", this.Name));
            }
            return result;
        }
        public void AddFunction(BaseFunction func)
        {
            functions.Add(func);
        }

    }
}
