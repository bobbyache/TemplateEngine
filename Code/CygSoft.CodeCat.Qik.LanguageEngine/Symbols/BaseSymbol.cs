using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    internal abstract class BaseSymbol : ISymbol 
    {
        private readonly string prefix = "@{";
        private readonly string postfix = "}";
        private readonly IErrorReport errorReport;

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsPlaceholder { get; private set; }
        public string Symbol { get; private set; }

        public abstract string Value { get; }

        public string Placeholder
        {
            get
            {
                if (this.Symbol != null)
                    return prefix + this.Symbol.Substring(1, this.Symbol.Length - 1) + postfix;
                else
                    return null;
            }
        }

        public BaseSymbol(IErrorReport errorReport, string symbol, string title, string description, bool isPlaceholder)
        {
            this.Symbol = symbol;
            this.Title = title;
            this.Description = description;
            this.IsPlaceholder = isPlaceholder;
            this.errorReport = errorReport;
        }

        public BaseSymbol(IErrorReport errorReport, string symbol, string title, string description, bool isPlaceholder, string prefix, string postfix)
        {
            this.prefix = prefix;
            this.postfix = postfix;

            this.Symbol = symbol;
            this.Title = title;
            this.Description = description;
            this.IsPlaceholder = IsPlaceholder;
            this.errorReport = errorReport;
        }
    }
}
