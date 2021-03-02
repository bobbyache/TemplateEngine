
namespace CygSoft.Qik.Console
{
    public interface IAppHost
    {
        string GetJsonInputInterface(string path);
        // TODO: Use the path to determine whether its a qik file or a folder
        // public string Read(string path)
        void Generate(string scriptFilePath, string inputs, string blueprintFileFolder);
    }
}
