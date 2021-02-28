using Antlr4.Runtime;
using CygSoft.Qik.Antlr;
using CygSoft.Qik.LanguageEngine.Antlr;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Symbols;
using System;
using System.Linq;
using CygSoft.Qik.LanguageEngine.Scope;

namespace CygSoft.Qik.LanguageEngine
{
    public class CompileEngine : ICompileEngine
    {
        public event EventHandler BeforeInput;
        public event EventHandler AfterInput;
        public event EventHandler BeforeCompile;
        public event EventHandler AfterCompile;
        public event EventHandler<CompileErrorEventArgs> CompileError;

        private readonly IGlobalTable scopeTable = new GlobalTable();
        private readonly IErrorReport errorReport = new ErrorReport();

        public bool HasErrors { get; private set; }

        public string[] Symbols => scopeTable.Symbols;

        public IInputField[] InputFields => scopeTable.InputFields;
        public IExpression[] Expressions => scopeTable.Expressions;

        public string[] Placeholders => scopeTable.Placeholders;

        public CompileEngine() => HasErrors = false;

        public void CreateFieldInput(string symbol, string fieldName, string description)
        {
            HasErrors = false;

            var autoInputSymbol = new AutoInputSymbol(symbol, fieldName, description);

            if (!scopeTable.Symbols.Contains(autoInputSymbol.Symbol))
                scopeTable.AddSymbol(autoInputSymbol);
        }

        public void Input(string symbol, string value)
        {
            HasErrors = false;

            BeforeInput?.Invoke(this, new EventArgs());

            scopeTable.Input(symbol, value);

            AfterInput?.Invoke(this, new EventArgs());
        }

        public void Compile(string scriptText)
        {
            HasErrors = false;
            BeforeCompile?.Invoke(this, new EventArgs());

            try
            {
                scopeTable.Clear();

                errorReport.Reporting = true;
                errorReport.ExecutionErrorDetected += ErrorReport_ExecutionErrorDetected;

                CompileInputs(scriptText);
                CompileExpressions(scriptText);

                errorReport.ExecutionErrorDetected -= ErrorReport_ExecutionErrorDetected;
                errorReport.Reporting = false;

                // this doesn't appear to be used...
                bool success = !this.errorReport.HasErrors;
                this.errorReport.Clear();
            }
            catch (Exception exception)
            {
                HasErrors = true;
                CompileError?.Invoke(this, new CompileErrorEventArgs(exception));
            }
            finally
            {
                AfterCompile?.Invoke(this, new EventArgs());
            }
        }

        private void CompileExpressions(string scriptText)
        {
            var inputStream = new AntlrInputStream(scriptText);
            var lexer = new QikTemplateLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QikTemplateParser(tokens);

            var tree = parser.template();

            var expressionVisitor = new ExpressionVisitor(this.scopeTable, this.errorReport);
            expressionVisitor.Visit(tree);
        }

        private void CompileInputs(string scriptText)
        {
            var inputStream = new AntlrInputStream(scriptText);
            var lexer = new QikTemplateLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QikTemplateParser(tokens);

            var tree = parser.template();

            var controlVisitor = new UserInputVisitor(this.scopeTable, this.errorReport);
            controlVisitor.Visit(tree);
        }

        private void ErrorReport_ExecutionErrorDetected(object sender, CompileErrorEventArgs e)
        {
            HasErrors = true;
            CompileError?.Invoke(this, e);
        }

        public ISymbolInfo GetSymbolInfo(string symbol) => scopeTable.GetSymbolInfo(symbol);

        public ISymbolInfo GetPlaceholderInfo(string placeholder) => scopeTable.GetPlaceholderInfo(placeholder);

        public ISymbolInfo[] GetSymbolInfoSet(string[] symbols) => scopeTable.GetSymbolInfoSet(symbols);

        public string GetValueOfSymbol(string symbol) => scopeTable.GetValueOfSymbol(symbol);

        public string GetValueOfPlaceholder(string placeholder) => scopeTable.GetValueOfPlacholder(placeholder);

        public string GetTitleOfPlaceholder(string placeholder) => scopeTable.GetTitleOfPlacholder(placeholder);
    }
}
