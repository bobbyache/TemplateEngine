using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IFunction
    {
        int Column { get; }
        int Line { get; }
        string Name { get; }

        string Execute(IErrorReport errorReport);
    }
}