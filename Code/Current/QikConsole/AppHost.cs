
using System;
using System.Text;
using System.Text.Json;

using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Symbols;

namespace CygSoft.Qik.Console
{
    public class AppHost : IAppHost
    {
        private readonly ICompiler compiler;
        private readonly IFileFunctions fileFunctions;
        private readonly IJsonFunctions jsonFunctions;
        public AppHost(ICompiler compiler, IFileFunctions fileFunctions, IJsonFunctions jsonFunctions)
        {
            this.compiler = compiler ?? throw new ArgumentNullException("ICompiler cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException("IFileFunctions cannot be null.");
            this.jsonFunctions = jsonFunctions ?? throw new ArgumentNullException("IJsonFunctions cannot be null.");
        }

        // TODO: Should just pass a path. Have the Api decide what to do with it.
        public string Read(string scriptFilePath)
        {
            var result = new StringBuilder();
            compiler.Compile(fileFunctions.ReadTextFile(scriptFilePath));

            result.Append("[");

            result.Append(jsonFunctions.SerializeInputSymbols(compiler));

            result.Append("]");

            // var scriptFilePath = Directory.EnumerateFiles(projectFolder, "*.qik").SingleOrDefault();

            // if (scriptFilePath is not null)
            // {
            //     compiler.Compile(ReadFileContents(scriptFilePath));
            //     result.Append("[");
            //     result.Append(SerializeInputSymbols(compiler));
            //     result.Append("]");
            //     Console.WriteLine(result.ToString());
            // }

            return result.ToString();
        }

        // TODO: Use the path to determine whether its a qik file or a folder
        // public string Read(string path)
        // {
        //     JsonApi jsonApi = new JsonApi();
        //     return jsonApi.ReadScript(projectFolder);
        // }

        //TODO: You want to input a JSON array here for key values pairs (symbol, value)
        public void Generate(string scriptFilePath, string inputs, string blueprintFileFolder)
        {
            throw new NotImplementedException();
        }
    }
}
