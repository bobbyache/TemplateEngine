
using System;
using System.IO;

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
        public string GetJsonInputInterface(string path)
        {
            compiler.Compile(fileFunctions.ReadTextFile(GetQikScriptPath(path)));
            return jsonFunctions.SerializeInputSymbols(compiler);
        }

        //TODO: You want to input a JSON array here for key values pairs (symbol, value)
        public void Generate(string scriptFilePath, string inputs, string blueprintFileFolder) => throw new NotImplementedException();

        private string GetQikScriptPath(string path)
        {
            if (fileFunctions.IsFolder(path))
            {
                var scriptFound = fileFunctions.FindQikScriptInFolder(path, out var scriptPath);
                if (scriptFound) return scriptPath;
            }
            else
                if (fileFunctions.IsQikScript(path)) return path;             

            throw new FileNotFoundException("Qik file not found.");
        }
    }
}
