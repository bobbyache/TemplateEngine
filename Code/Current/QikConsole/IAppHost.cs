
namespace CygSoft.Qik.Console
{
    public interface IAppHost
    {
        string GetJsonInputInterface(string path);
        void Generate(string path, string blueprintExtensions);
    }
}
