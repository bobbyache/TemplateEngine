﻿using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class ConcatenateFunction : BaseFunction
    {
        private readonly List<BaseFunction> functions = new List<BaseFunction>();

        internal ConcatenateFunction(IFuncInfo funcInfo, IGlobalTable scopeTable)
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
