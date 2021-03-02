
namespace CygSoft.Qik.Functions
{
    public interface IFunction
    {
        int Column { get; }
        int Line { get; }
        string Name { get; }

        string Execute(IErrorReport errorReport);
    }
}