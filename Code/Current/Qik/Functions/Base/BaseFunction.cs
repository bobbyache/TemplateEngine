using System;
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

        public BaseFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, List<IFunction> functionArguments = null)
        {
            if (funcInfo is null) throw new ArgumentNullException($"{nameof(funcInfo)} cannot be null.");
            this.scopeTable = scopeTable ?? throw new ArgumentNullException($"{nameof(scopeTable)} cannot be null.");

            Line = funcInfo.Line;
            Column = funcInfo.Column;
            Name = funcInfo.Name;

            this.functionArguments = functionArguments ?? new List<IFunction>();
        }

        // TODO: Believe this error report should go in via constructor
        // Derived function should call into BaseFunction protected method to set error report.
        // In that way, eliminate interface dependency on IErrorReport
        public abstract string Execute(IErrorReport errorReport);
    }
}
