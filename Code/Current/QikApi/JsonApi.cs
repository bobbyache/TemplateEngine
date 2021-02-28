using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Symbols;
using CygSoft.Qik.LanguageEngine;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace QikApi
{
    public class JsonApi
    {

        //TODO: You want to input a JSON array here for key values pairs (symbol, value)
        // public string Input(string inputData)
        // {
        //     compiler.Input("@table", "MyTable");
        // }

        public string ReadScript(string script)
        {
            var result = new StringBuilder();
            var compiler = new Compiler();
            compiler.Compile(script);

            result.Append("{");
            result.Append("\"inputs\": [");

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
            result.Append("],");
            result.Append("\"expressions\": [");

            for (var i = 0; i < compiler.Expressions.Length; i++)
            {
                var expression = compiler.Expressions[i];

                if (expression is ExpressionSymbol)
                {
                    result.Append(JsonSerializer.Serialize<ExpressionSymbol>(expression as ExpressionSymbol));
                }
                if (i < compiler.Expressions.Length - 1)
                {
                    result.Append(",");
                }
            }
            result.Append("]");

            result.Append("}");

            Console.WriteLine(result.ToString());

            return result.ToString();
        }
    }
}
