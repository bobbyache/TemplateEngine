using CygSoft.Qik.LanguageEngine.Infrastructure;
using System.Collections.Generic;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    public abstract class BaseFunction : IFunction
    {
        protected IGlobalTable scopeTable = null;
        protected List<IFunction> functionArguments;

        public int Line { get; private set; }
        public int Column { get; private set; }
        public string Name { get; private set; }

        public BaseFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, List<IFunction> functionArguments)
        {
            this.Line = funcInfo.Line;
            this.Column = funcInfo.Column;
            this.Name = funcInfo.Name;
            this.scopeTable = scopeTable;
            this.functionArguments = functionArguments;
        }

        public BaseFunction(IFuncInfo funcInfo, IGlobalTable scopeTable)
        {
            this.Line = funcInfo.Line;
            this.Column = funcInfo.Column;
            this.Name = funcInfo.Name;
            this.scopeTable = scopeTable;
            this.functionArguments = new List<IFunction>();
        }

        public abstract string Execute(IErrorReport errorReport);
    }
}
