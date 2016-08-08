using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    internal class ExpressionSymbol : BaseSymbol, IExpression
    {
        private BaseFunction func;

        public ExpressionSymbol(string symbol, string title, BaseFunction func)
            : base(symbol, title)
        {
            this.func = func;
        }

        public ExpressionSymbol(string symbol, string title, BaseFunction func, string prefix, string postfix)
            : base(symbol, title, prefix, postfix)
        {
            this.func = func;
        }

        public override string Value
        {
            get { return func.Execute(); }
        }
    }
}
