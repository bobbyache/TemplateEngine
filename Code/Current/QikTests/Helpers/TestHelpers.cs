using CygSoft.Qik;

namespace LanguageEngine.Tests.UnitTests.Helpers
{
    public class TestHelpers
    {
        internal static string EvaluateFunction(string functionText)
        {
            var interpreter = new Intepreter();
            var expression = TestHelpers.BuildExpressionForFunction(functionText);

            interpreter.Interpret(expression);
            var val = interpreter.GetValueOfSymbol("@output");

            return val;
        }

        internal static OptionInputSymbol CreateOptionInputSymbol_DatabaseOptions(string symbol = "@databaseOptions", string title = "Database Options", string description = null, string defaultValue = null, bool isPlaceholder = true)
        {
            var optionInputSymbol = new OptionInputSymbol(symbol, title, description, defaultValue, isPlaceholder);
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            return optionInputSymbol;
        }

        internal static IOptionsField CreateOptionInputSymbol_DatabaseOptions_AsInterface(string symbol = "@databaseOptions", string title = "Database Options", string description = null, string defaultValue = null, bool isPlaceholder = true)
        {
            var optionInputSymbol = new OptionInputSymbol(symbol, title, description, defaultValue, isPlaceholder);
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            return optionInputSymbol as IOptionsField;
        }

        internal static TextInputSymbol CreateTextInputSymbol_Author(string symbol = "@authorName", string title = "Author Name", string description = null, string defaultValue = null, bool isPlaceholder = true)
        {
            var textInputSymbol = new TextInputSymbol(symbol, title, description, defaultValue, isPlaceholder);
            return textInputSymbol;
        }

        private static string BuildExpressionForFunction(string functionText)
        {
            return "@output = expression [Title=\"Expression Text\"] { return " + functionText + "; };";
        }
    }
}
