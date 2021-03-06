﻿
namespace CygSoft.Qik.Functions
{
    public class IntegerFunction : BaseFunction
    {
        private readonly string text;

        public IntegerFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string text)
            : base(funcInfo, scopeTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return this.text;
        }
    }
}
