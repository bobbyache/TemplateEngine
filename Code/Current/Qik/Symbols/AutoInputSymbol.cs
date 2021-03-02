
namespace CygSoft.Qik
{
    public class AutoInputSymbol : InputSymbol
    {
        private string value = null;

        public AutoInputSymbol(string symbol, string title, string description) : base(symbol, title, description, null, true)
        {
            value = null;
        }

        public AutoInputSymbol(string symbol, string title, string description, string prefix, string postfix)
            : base(symbol, title, description, null, true, prefix, postfix)
        {
            value = null;
        }

        public override string Value => value;

        public void SetValue(string value) => this.value = value;
    }
}
