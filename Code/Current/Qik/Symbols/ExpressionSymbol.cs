using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    public class ExpressionSymbol : BaseSymbol, IExpression
    {
        private readonly IFunction func;
        public bool IsVisibleToEditor { get; }
        private readonly IErrorReport errorReport;

        public ExpressionSymbol(IErrorReport errorReport, string symbol, string title, string description, 
            bool isPlaceholder, bool isVisibleToEditor, IFunction func)
            : base(symbol, title, description, isPlaceholder)
        {
            this.func = func;
            this.errorReport = errorReport;
            IsVisibleToEditor = isVisibleToEditor;
        }

        public ExpressionSymbol(IErrorReport errorReport, string symbol, string title, string description, 
            bool isPlaceholder, bool isVisibleToEditor, IFunction func, string prefix, string postfix)
            : base(symbol, title, description, isPlaceholder, prefix, postfix)
        {
            this.func = func;
            this.errorReport = errorReport;
            IsVisibleToEditor = isVisibleToEditor;
        }

        public override string Value => func.Execute(errorReport);
    }
}
