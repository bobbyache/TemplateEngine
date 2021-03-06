using Antlr4.Runtime;
using System;

namespace CygSoft.Qik.Antlr
{
    // TODO: Move into Interpreter folder where it belongs.
    public class SyntaxValidator : ISyntaxValidator
    {
        public event EventHandler<CompileErrorEventArgs> CompileError;

        public bool HasErrors { get; private set; }

        public SyntaxValidator() => HasErrors = false;

        public void Validate(string scriptText)
        {
            HasErrors = false;
            
            // TODO: Can't this stuff all be injected and mocked out for testing?
            var inputStream = new AntlrInputStream(scriptText);
            var lexer = new QikTemplateLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QikTemplateParser(tokens);

            var errorListener = new ErrorListener();
            errorListener.SyntaxErrorDetected += ErrorListener_SyntaxErrorDetected;
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);
            parser.template();
            errorListener.SyntaxErrorDetected -= ErrorListener_SyntaxErrorDetected;
        }

        private void ErrorListener_SyntaxErrorDetected(object sender, CompileErrorEventArgs e)
        {
            HasErrors = true;
            CompileError?.Invoke(this, e);
        }
    }
}
