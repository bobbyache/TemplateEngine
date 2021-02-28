
using CygSoft.Qik.Api;
using System;
using System.IO;

namespace CygSoft.Qik.Console
{
    public class InputManifestHandler : IInputManifestHandler
    {

        public string Read(string scriptFilePath)
        {
            JsonApi jsonApi = new JsonApi();
            return jsonApi.ReadScript(ReadFileContents(scriptFilePath));
        }

        public void Generate(string scriptFilePath, string inputs, string blueprintFileFolder)
        {
            throw new NotImplementedException();
        }

        private string ReadFileContents(string filePath)
        {
            string contents = null;
            // Specify file, instructions, and priveledges
            using (var file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                // Create a new stream to read from a file
                using (StreamReader sr = new StreamReader(file))
                {
                    contents = sr.ReadToEnd();
                }
            }
            return contents;
        }
    }
}
