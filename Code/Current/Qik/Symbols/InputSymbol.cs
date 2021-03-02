
namespace CygSoft.Qik
{
    public abstract class InputSymbol : BaseSymbol, IInputField
    {
        public string DefaultValue { get; }

        public InputSymbol(string symbol, string title, string description, string defaultValue, 
            bool isPlaceholder)
            : base(symbol, title, description, isPlaceholder)
        {
            DefaultValue = Common.StripOuterQuotes(defaultValue);
        }

        public InputSymbol(string symbol, string title, string description, string defaultValue, bool isPlaceholder,  
            string prefix, string postfix)
            : base(symbol, title, description, isPlaceholder, prefix, postfix)
        {
            DefaultValue = defaultValue;
        }
    }
}
