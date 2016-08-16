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
        public bool IsVisibleToEditor { get; private set; }

        public ExpressionSymbol(string symbol, string title, string description, 
            bool isPlaceholder, bool isVisibleToEditor, BaseFunction func)
            : base(symbol, title, description, isPlaceholder)
        {
            this.func = func;
            this.IsVisibleToEditor = isVisibleToEditor;
        }

        public ExpressionSymbol(string symbol, string title, string description, 
            bool isPlaceholder, bool isVisibleToEditor, BaseFunction func, string prefix, string postfix)
            : base(symbol, title, description, isPlaceholder, prefix, postfix)
        {
            this.func = func;
            this.IsVisibleToEditor = IsVisibleToEditor;
        }

        public override string Value
        {
            get { return func.Execute(); }
        }
    }
}
