namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IFuncInfo
    {
        int Column { get; }
        int Line { get; }
        string Name { get; }
    }
}