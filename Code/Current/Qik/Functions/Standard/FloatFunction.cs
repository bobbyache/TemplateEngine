
namespace CygSoft.Qik.Functions
{
    public class FloatFunction : BaseFunction
    {
        private readonly string text;

        public FloatFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string text)
            : base(funcInfo, scopeTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return text;
        }
    }
}
