
namespace CygSoft.Qik.Functions
{
    public class TextFunction : BaseFunction
    {
        private readonly string text;

        public TextFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string text) : base(funcInfo, scopeTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return this.text;
        }
    }
}
