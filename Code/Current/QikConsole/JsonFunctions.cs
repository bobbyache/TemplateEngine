using System;
using System.Text;
using System.Text.Json;

namespace CygSoft.Qik.Console
{
    public interface IJsonFunctions
    {
        string SerializeInputSymbols(ICompiler compiler);
        InputSymbol[] DeserializeInput(string jsonKeyValues);
    }

    public class InputSymbol
    {
        public string Symbol { get; set; }
        public string Value { get; set; }
    }

    public class JsonFunctions : IJsonFunctions
    {
        private readonly ICompiler compiler;
        public JsonFunctions(ICompiler compiler)
        {
            this.compiler = compiler ?? throw new ArgumentNullException("ICompiler cannot be null.");
        }

        public InputSymbol[] DeserializeInput(string jsonKeyValues)
        {
            JsonSerializerOptions opts = new JsonSerializerOptions();
            // TODO: Get this to work... currently JSON has to be proper case.
            opts.PropertyNameCaseInsensitive = false;
            
            var values = JsonSerializer.Deserialize<InputSymbol[]>(jsonKeyValues);
            return values;
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