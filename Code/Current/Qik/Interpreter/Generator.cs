
namespace CygSoft.Qik
{
    // TODO: The Generator should not be in here. Replacement and output is really not a concern for the Qik engine.
    public class Generator : IGenerator
    {
        // TODO: Instead of passing in an interpreter, should just pass in the processed placeholder output.
        public string Generate(IInterpreter interpreter, string templateText)
        {
            var input = templateText;

            foreach (var placeholder in interpreter.Placeholders)
            {
                var output = interpreter.GetValueOfPlaceholder(placeholder);
                input = input.Replace(placeholder, output);
            }

            return input;
        }
    }
}
