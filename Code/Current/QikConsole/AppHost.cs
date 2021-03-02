
using System;
using System.IO;
using System.Collections.Generic;

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

        public string GetJsonInputInterface(string path)
        {
            compiler.Compile(fileFunctions.ReadTextFile(GetQikScriptPath(path)));
            return jsonFunctions.SerializeInputSymbols(compiler);
        }

        public void Generate(string path)
        {
            var inputFile = GetInputPath(path);
            var scriptFile = GetQikScriptPath(path);
            var bluePrintFiles = GetBlueprintPaths(path);

            compiler.Compile(fileFunctions.ReadTextFile(scriptFile));

            if (fileFunctions.FileExists(inputFile))
            {
                var txt = fileFunctions.ReadTextFile(inputFile);
                var inputs = jsonFunctions.DeserializeInput(fileFunctions.ReadTextFile(inputFile));

                foreach (var input in inputs)
                {
                    compiler.Input(input.Symbol, input.Value);
                }
            }

            foreach (var bluePrintFile in bluePrintFiles)
            {
                var generator = new Generator();
                string output = generator.Generate(compiler, fileFunctions.ReadTextFile(bluePrintFile));

                var outputPath = fileFunctions.GeneratOutputPath(bluePrintFile);
                fileFunctions.WriteTextFile(outputPath, output);
            }
        }

        private IEnumerable<string> GetBlueprintPaths(string path)
        {
            if (fileFunctions.IsFolder(path))
            {
                var scriptFound = fileFunctions.FindBlueprintFilesInFolder(path, out var bluePrints);
                if (scriptFound) return bluePrints;
            }
            else
                if (fileFunctions.IsBlueprint(path)) return new List<string>() { path };     

            throw new FileNotFoundException("Blueprint file not found.");
        }

        private string GetInputPath(string path)
        {
            if (fileFunctions.IsFolder(path))
            {
                var scriptFound = fileFunctions.FindInputsFileInFolder(path, out var scriptPath);
                if (scriptFound) return scriptPath;
            }
            else
                if (fileFunctions.IsInputsFile(path)) return path;             

            throw new FileNotFoundException("Input file not found.");
        }

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
