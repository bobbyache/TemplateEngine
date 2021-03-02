
using System;

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
            compiler.Compile(fileFunctions.ReadTextFile(scriptFilePath));

            return jsonFunctions.SerializeInputSymbols(compiler);

            // var scriptFilePath = Directory.EnumerateFiles(projectFolder, "*.qik").SingleOrDefault();

            // if (scriptFilePath is not null)
            // {
            //     compiler.Compile(ReadFileContents(scriptFilePath));
            //     result.Append("[");
            //     result.Append(SerializeInputSymbols(compiler));
            //     result.Append("]");
            //     Console.WriteLine(result.ToString());
            // 
        }

        //TODO: You want to input a JSON array here for key values pairs (symbol, value)
        public void Generate(string scriptFilePath, string inputs, string blueprintFileFolder)
        {
            throw new NotImplementedException();
        }
    }
}
