using CygSoft.Qik.LanguageEngine.Infrastructure;
using System.Collections.Generic;

namespace CygSoft.Qik.Functions
{
    public abstract class BaseFunction : IFunction
    {
        protected IGlobalTable scopeTable = null;
        protected List<IFunction> functionArguments;

        public int Line { get; }
        public int Column { get;}
        public string Name { get; }

        public BaseFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, List<IFunction> functionArguments)
        {
            Line = funcInfo.Line;
            Column = funcInfo.Column;
            Name = funcInfo.Name;
            this.scopeTable = scopeTable;
            this.functionArguments = functionArguments;
        }

        public BaseFunction(IFuncInfo funcInfo, IGlobalTable scopeTable)
        {
            Line = funcInfo.Line;
            Column = funcInfo.Column;
            Name = funcInfo.Name;
            this.scopeTable = scopeTable;
            functionArguments = new List<IFunction>();
        }

        public abstract string Execute(IErrorReport errorReport);
    }
}
