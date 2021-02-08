using Antlr4.Runtime;
using CygSoft.Qik.LanguageEngine.Antlr;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;

namespace CygSoft.Qik.LanguageEngine
{
    public class SyntaxValidator : ISyntaxValidator
    {
        public event EventHandler<CompileErrorEventArgs> CompileError;

        public bool HasErrors { get; private set; }

        public SyntaxValidator()
        {
            HasErrors = false;
        }

        public void Validate(string scriptText)
        {
            HasErrors = false;

            AntlrInputStream inputStream = new AntlrInputStream(scriptText);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            ErrorListener errorListener = new ErrorListener();
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
