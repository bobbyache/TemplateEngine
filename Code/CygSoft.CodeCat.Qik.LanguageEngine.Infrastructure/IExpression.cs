namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IExpression : ISymbol
    {
        bool IsVisibleToEditor { get; }
    }
}
