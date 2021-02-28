
using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    public class TextInputSymbol : InputSymbol, ITextField
    {
        private string value = null;

        public override string Value => value;

        public TextInputSymbol(string symbol, string title, string description, string defaultValue, 
            bool isPlaceholder)
            : base(symbol, title, description, defaultValue, isPlaceholder)
        {
            value = defaultValue;
        }

        public TextInputSymbol(string symbol, string title, string description, string defaultValue, bool isPlaceholder,
            string prefix, string postfix)
            : base(symbol, title, description, defaultValue, isPlaceholder, prefix, postfix)
        {
            value = defaultValue;
        }

        public void SetValue(string value) => this.value = value;
    }
}
