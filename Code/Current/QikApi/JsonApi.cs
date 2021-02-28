using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Symbols;
using CygSoft.Qik.LanguageEngine;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CygSoft.Qik.Api
{
    public class JsonApi
    {

        //TODO: You want to input a JSON array here for key values pairs (symbol, value)
        public string[] Generate(string inputData, string[] bluePrintTexts)
        {
            throw new NotImplementedException();
            //return new string[0];
        }

        // TODO: Should just pass a path. Have the Api decide what to do with it.
        public string ReadScript(string scriptFilePath)
        {
            var result = new StringBuilder();
            var compiler = new Compiler();
            compiler.Compile(ReadFileContents(scriptFilePath));

            result.Append("[");

            result.Append(SerializeInputSymbols(compiler));

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

        private string SerializeInputSymbols(ICompiler compiler)
        {
            var result = new StringBuilder();

            for (var i = 0; i < compiler.InputFields.Length; i++)
            {
                var inputField = compiler.InputFields[i];

                if (inputField is TextInputSymbol)
                {
                    result.Append(JsonSerializer.Serialize<TextInputSymbol>(inputField as TextInputSymbol));
                }
                else if (inputField is OptionInputSymbol)
                {
                    result.Append(JsonSerializer.Serialize<OptionInputSymbol>(inputField as OptionInputSymbol));
                }

                if (i < compiler.InputFields.Length - 1)
                {
                    result.Append(",");
                }
            }

            return result.ToString();
        }
    }
}
