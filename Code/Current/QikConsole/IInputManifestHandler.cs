
namespace CygSoft.Qik.Console
{
    public interface IInputManifestHandler
    {
        string Read(string scriptFilePath);
        void Generate(string scriptFilePath, string inputs, string blueprintFileFolder);
    }
}
