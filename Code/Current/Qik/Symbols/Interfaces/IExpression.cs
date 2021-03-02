namespace CygSoft.Qik
{
    public interface IExpression : ISymbol
    {
        bool IsVisibleToEditor { get; }
    }
}
