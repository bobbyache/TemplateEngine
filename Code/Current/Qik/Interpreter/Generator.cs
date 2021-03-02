
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

        public string Generate(ICompiler compiler, string templateText)
        {
            var input = templateText;

            foreach (var placeholder in compiler.Placeholders)
            {
                var output = compiler.GetValueOfPlaceholder(placeholder);
                input = input.Replace(placeholder, output);
            }

            return input;
        }
    }
}
