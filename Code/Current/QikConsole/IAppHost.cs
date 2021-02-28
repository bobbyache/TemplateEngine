
namespace CygSoft.Qik.Console
{
    public interface IAppHost
    {
        string Read(string scriptFilePath);
        // TODO: Use the path to determine whether its a qik file or a folder
        // public string Read(string path)
        void Generate(string scriptFilePath, string inputs, string blueprintFileFolder);
    }
}
