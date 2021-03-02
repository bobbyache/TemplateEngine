using System;
using System.Text;
using System.Text.Json;

using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.Console
{
    public interface IJsonFunctions
    {
        string SerializeInputSymbols(ICompiler compiler);
    }

    public class JsonFunctions : IJsonFunctions
    {
        private readonly ICompiler compiler;
        public JsonFunctions(ICompiler compiler)
        {
            this.compiler = compiler ?? throw new ArgumentNullException("ICompiler cannot be null.");
        }

        public string SerializeInputSymbols(ICompiler compiler)
        {
            var result = new StringBuilder();

            result.Append("[");

            for (var i = 0; i < compiler.InputFields.Length; i++)
            {
                var inputField = compiler.InputFields[i];

                if (inputField is TextInputSymbol textInputField)
                {
                    result.Append(JsonSerializer.Serialize<TextInputSymbol>(textInputField));
                }
                else if (inputField is OptionInputSymbol optionInputField)
                {
                    result.Append(JsonSerializer.Serialize<OptionInputSymbol>(optionInputField));
                }

                if (i < compiler.InputFields.Length - 1)
                {
                    result.Append(",");
                }
            }

            result.Append("]");

            return result.ToString();
        }
    }
}