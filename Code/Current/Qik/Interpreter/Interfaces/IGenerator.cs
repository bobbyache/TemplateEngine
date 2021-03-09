namespace CygSoft.Qik
{
    public interface IGenerator
    {
        string Generate(IInterpreter interpreter, string templateText);
        string Generate(IBatchCompiler interpreter, string templateText);
    }
}
