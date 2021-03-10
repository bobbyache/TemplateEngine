using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CygSoft.Qik.Console
{
    public interface IJsonFunctions
    {
        string SerializeInputSymbols();
        InputSymbol[] DeserializeInput(string jsonKeyValues);
    }

    public class InputSymbol
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class JsonFunctions : IJsonFunctions
    {
        private readonly IInterpreter interpreter;
        public JsonFunctions(IInterpreter interpreter)
        {
            this.interpreter = interpreter ?? throw new ArgumentNullException($"{nameof(interpreter)} cannot be null.");
        }

        public InputSymbol[] DeserializeInput(string jsonKeyValues)
        {
            var values = JsonSerializer.Deserialize<InputSymbol[]>(jsonKeyValues);
            return values;
        }

        public string SerializeInputSymbols()
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var result = new StringBuilder();

            result.Append("[");

            for (var i = 0; i < interpreter.InputFields.Length; i++)
            {
                var inputField = interpreter.InputFields[i];

                if (inputField is TextInputSymbol textInputField)
                    result.Append(JsonSerializer.Serialize<TextInputSymbol>(textInputField, options));

                else if (inputField is OptionInputSymbol optionInputField)
                    result.Append(JsonSerializer.Serialize<OptionInputSymbol>(optionInputField, options));

                if (i < interpreter.InputFields.Length - 1)
                    result.Append(",");
            }

            result.Append("]");

            return result.ToString();
        }
    }
}