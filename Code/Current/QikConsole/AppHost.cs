
using System;
using System.IO;
using System.Collections.Generic;

namespace CygSoft.Qik.Console
{
    public class AppHost : IAppHost
    {
        private readonly IInterpreter interpreter;
        private readonly IFileFunctions fileFunctions;
        private readonly IJsonFunctions jsonFunctions;
        public AppHost(IInterpreter interpreter, IFileFunctions fileFunctions, IJsonFunctions jsonFunctions)
        {
            this.interpreter = interpreter ?? throw new ArgumentNullException("ICompiler cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException("IFileFunctions cannot be null.");
            this.jsonFunctions = jsonFunctions ?? throw new ArgumentNullException("IJsonFunctions cannot be null.");
        }

        // TODO: Generate a human readable text file that explains how the options can be
        // set from the InputSymbols Json. Call it input_manual.txt.
        public string GetJsonInputInterface(string path)
        {
            var scriptFile = GetQikScriptPath(path);
            interpreter.Interpret(fileFunctions.ReadTextFile(GetQikScriptPath(path)));
            return jsonFunctions.SerializeInputSymbols(interpreter);
        }

        public void Generate(string path)
        {
            var inputFile = GetInputPath(path);
            var scriptFile = GetQikScriptPath(path);
            var bluePrintFiles = GetBlueprintPaths(path);

            interpreter.Interpret(fileFunctions.ReadTextFile(scriptFile));

            if (fileFunctions.FileExists(inputFile))
            {
                var txt = fileFunctions.ReadTextFile(inputFile);
                var inputs = jsonFunctions.DeserializeInput(fileFunctions.ReadTextFile(inputFile));

                foreach (var input in inputs)
                {
                    interpreter.Input(input.Symbol, input.Value);
                }
            }

            foreach (var bluePrintFile in bluePrintFiles)
            {
                var generator = new Generator();
                string output = generator.Generate(interpreter, fileFunctions.ReadTextFile(bluePrintFile));

                var outputPath = fileFunctions.GeneratOutputPath(bluePrintFile);
                fileFunctions.WriteTextFile(outputPath, output);
            }
        }

        private IEnumerable<string> GetBlueprintPaths(string path)
        {
            if (fileFunctions.IsFolder(path))
            {
                var blueprintsFound = fileFunctions.FindBlueprintFilesInFolder(path, out var bluePrints);
                if (blueprintsFound) return bluePrints;
            }
            else
            {
                var blueprintsFound = fileFunctions.FindBlueprintFilesInFolder(fileFunctions.GetFileDirectory(path), out var blueprintPaths);
                if (blueprintsFound) return blueprintPaths;
            } 

            throw new FileNotFoundException("Blueprint file not found.");
        }

        private string GetInputPath(string path)
        {
            if (fileFunctions.IsFolder(path))
            {
                var inputFound = fileFunctions.FindInputsFileInFolder(path, out var inputPath);
                if (inputFound) return inputPath;
            }
            else
            {
                var inputFound = fileFunctions.FindInputsFileInFolder(fileFunctions.GetFileDirectory(path), out var inputPath);
                if (inputFound) return inputPath;
            }         

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
