
using CygSoft.Qik.Api;
using System;

namespace CygSoft.Qik.Console
{
    public class AppHost : IAppHost
    {
        public string Read(string scriptFilePath)
        {
            JsonApi jsonApi = new JsonApi();
            return jsonApi.ReadScript(scriptFilePath);
        }

        // TODO: Use the path to determine whether its a qik file or a folder
        // public string Read(string path)
        // {
        //     JsonApi jsonApi = new JsonApi();
        //     return jsonApi.ReadScript(projectFolder);
        // }

        public void Generate(string scriptFilePath, string inputs, string blueprintFileFolder)
        {
            throw new NotImplementedException();
        }
    }
}
