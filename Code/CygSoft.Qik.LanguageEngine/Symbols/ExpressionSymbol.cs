using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    internal class ExpressionSymbol : BaseSymbol, IExpression
    {
        private readonly IFunction func;
        public bool IsVisibleToEditor { get; private set; }
        private readonly IErrorReport errorReport;

        public ExpressionSymbol(IErrorReport errorReport, string symbol, string title, string description, 
            bool isPlaceholder, bool isVisibleToEditor, IFunction func)
            : base(symbol, title, description, isPlaceholder)
        {
            this.func = func;
            this.IsVisibleToEditor = isVisibleToEditor;
            this.errorReport = errorReport;
        }

        public ExpressionSymbol(IErrorReport errorReport, string symbol, string title, string description, 
            bool isPlaceholder, bool isVisibleToEditor, IFunction func, string prefix, string postfix)
            : base(symbol, title, description, isPlaceholder, prefix, postfix)
        {
            this.func = func;
            this.IsVisibleToEditor = IsVisibleToEditor;
            this.errorReport = errorReport;
        }

        public override string Value
        {
            get { return func.Execute(errorReport); }
        }
    }
}
