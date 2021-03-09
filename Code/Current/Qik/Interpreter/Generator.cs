
namespace CygSoft.Qik
{
    public class Generator : IGenerator
    {
        public string Generate(IBatchCompiler batchCompiler, string templateText)
        {
            var input = templateText;

            foreach (var placeholder in batchCompiler.Placeholders)
            {
                var output = batchCompiler.GetValueOfPlaceholder(placeholder);
                input = input.Replace(placeholder, output);
            }

            return input;
        }

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
