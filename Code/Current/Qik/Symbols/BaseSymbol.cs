namespace CygSoft.Qik
{
    public abstract class BaseSymbol : ISymbol 
    {
        private readonly string prefix = "@{";
        private readonly string postfix = "}";

        public string Title { get; }
        public string Description { get; }
        public bool IsPlaceholder { get; }
        public string Symbol { get; }

        public abstract string Value { get; }

        public string Placeholder
        {
            get
            {
                if (Symbol != null)
                    return prefix + Symbol.Substring(1, Symbol.Length - 1) + postfix;
                else
                    return null;
            }
        }

        public BaseSymbol(string symbol, string title, string description, bool isPlaceholder)
        {
            Symbol = symbol;
            Title = title;
            Description = description;
            IsPlaceholder = isPlaceholder;
        }

        public BaseSymbol(string symbol, string title, string description, bool isPlaceholder, string prefix, string postfix)
        {
            this.prefix = prefix;
            this.postfix = postfix;

            Symbol = symbol;
            Title = title;
            Description = description;
            IsPlaceholder = isPlaceholder;
        }
    }
}
