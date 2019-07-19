namespace CygSoft.Qik.LanguageEngine.FunctionPlugins
{
    public interface IFuncInfo
    {
        int Column { get; }
        int Line { get; }
        string Name { get; }
    }
}