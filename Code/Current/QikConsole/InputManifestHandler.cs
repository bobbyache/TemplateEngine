
using CygSoft.Qik.Api;
using System;

namespace CygSoft.Qik.Console
{
    public class InputManifestHandler : IInputManifestHandler
    {

        public string Read(string scriptFilePath)
        {
            JsonApi jsonApi = new JsonApi();
            return jsonApi.ReadScript(scriptFilePath);
        }

        public void Generate(string scriptFilePath, string inputs, string blueprintFileFolder)
        {
            throw new NotImplementedException();
        }
    }
}
