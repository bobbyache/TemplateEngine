
namespace CygSoft.Qik.Console
{
    public class AppHost : IAppHost
    {
        private readonly IInputManifestHandler inputManifestHandler;

        public AppHost(IInputManifestHandler inputManifestHandler)
        {
            this.inputManifestHandler = inputManifestHandler;
        }

        public string ReadInputManfest(string scriptFilePath)
        {
            return inputManifestHandler.Read(scriptFilePath);
        }
    }
}
