using CygSoft.Qik.LanguageEngine.Infrastructure;
using System.Collections.Generic;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal abstract class BaseFunction
    {
        protected IGlobalTable scopeTable = null;
        protected List<BaseFunction> functionArguments;

        public int Line { get; private set; }
        public int Column { get; private set; }
        public string Name { get; private set; }

        internal BaseFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, List<BaseFunction> functionArguments)
        {
            this.Line = funcInfo.Line;
            this.Column = funcInfo.Column;
            this.Name = funcInfo.Name;
            this.scopeTable = scopeTable;
            this.functionArguments = functionArguments;
        }

        internal BaseFunction(IFuncInfo funcInfo, IGlobalTable scopeTable)
        {
            this.Line = funcInfo.Line;
            this.Column = funcInfo.Column;
            this.Name = funcInfo.Name;
            this.scopeTable = scopeTable;
            this.functionArguments = new List<BaseFunction>();
        }

        public abstract string Execute(IErrorReport errorReport);
    }
}
