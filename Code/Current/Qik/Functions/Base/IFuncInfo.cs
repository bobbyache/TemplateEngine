namespace CygSoft.Qik.Functions
{
    public interface IFuncInfo
    {
        int Column { get; }
        int Line { get; }
        string Name { get; }
    }
}