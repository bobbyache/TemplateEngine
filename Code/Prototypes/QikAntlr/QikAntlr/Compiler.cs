using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CygSoft.Qik.LanguageEngine.Antlr;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;
using QikAntlr.Antlr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine
{
    public class Compiler : ICompiler
    {
        public event EventHandler<CompileErrorEventArgs> CompileError;
        public event EventHandler BeforeCompile;
        public event EventHandler AfterCompile;

        public event EventHandler BeforeInput;
        public event EventHandler AfterInput;

        private GlobalTable scopeTable = new GlobalTable();
        private IErrorReport errorReport = new ErrorReport();

        public bool HasErrors { get; private set; }

        public string[] Symbols
        {
            get { return scopeTable.Symbols; }
        }

        public string[] Placeholders
        {
            get { return scopeTable.Placeholders; }
        }

        public string GetValueOfSymbol(string symbol)
        {
            return scopeTable.GetValueOfSymbol(symbol);
        }

        public string GetValueOfPlaceholder(string placeholder)
        {
            return scopeTable.GetValueOfPlacholder(placeholder);
        }

        public string GetTitleOfPlaceholder(string placeholder)
        {
            return scopeTable.GetTitleOfPlacholder(placeholder);
        }

        public IInputField[] InputFields { get { return scopeTable.InputFields; } }
        public IExpression[] Expressions { get { return scopeTable.Expressions; } }

        public void Compile(string scriptText)
        {
            this.HasErrors = false;

            if (BeforeCompile != null)
                BeforeCompile(this, new EventArgs());

            scopeTable.Clear();

            try
            {
                CheckSyntax(scriptText);
                if (!this.HasErrors)
                {
                    errorReport.Reporting = true;
                    errorReport.ExecutionErrorDetected += errorReport_ExecutionErrorDetected;

                    GetControls(scriptText);
                    GetExpressions(scriptText);
                    CheckExecution();

                    errorReport.ExecutionErrorDetected -= errorReport_ExecutionErrorDetected;
                    errorReport.Reporting = false;

                    bool success = !this.errorReport.HasErrors;
                    this.errorReport.Clear();
                }
            }
            catch (Exception exception)
            {
                if (CompileError != null)
                    CompileError(this, new CompileErrorEventArgs(exception));
            }

            if (AfterCompile != null)
                AfterCompile(this, new EventArgs());
        }

        public void Input(string symbol, string value)
        {
            if (BeforeInput != null)
                BeforeInput(this, new EventArgs());

            scopeTable.Input(symbol, value);

            if (AfterInput != null)
                AfterInput(this, new EventArgs());
        }

        private void CheckExecution()
        {
            foreach (IExpression expression in this.Expressions)
            {
                string value = expression.Value;
            }
        }

        private void CheckSyntax(string scriptText)
        {
            AntlrInputStream inputStream = new AntlrInputStream(scriptText);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            ErrorListener errorListener = new ErrorListener();
            errorListener.SyntaxErrorDetected += errorListener_SyntaxErrorDetected;
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);
            parser.template();
            errorListener.SyntaxErrorDetected -= errorListener_SyntaxErrorDetected;
        }

        private void errorReport_ExecutionErrorDetected(object sender, CompileErrorEventArgs e)
        {
            this.HasErrors = true;

            if (CompileError != null)
                CompileError(this, e);
        }

        private void errorListener_SyntaxErrorDetected(object sender, CompileErrorEventArgs e)
        {
            this.HasErrors = true;

            if (CompileError != null)
                CompileError(this, e);
        }

        private void GetControls(string scriptText)
        {
            AntlrInputStream inputStream = new AntlrInputStream(scriptText);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            IParseTree tree = parser.template();
            
            UserInputVisitor controlVisitor = new UserInputVisitor(this.scopeTable, this.errorReport);
            controlVisitor.Visit(tree);
        }

        private void GetExpressions(string scriptText)
        {
            AntlrInputStream inputStream = new AntlrInputStream(scriptText);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            IParseTree tree = parser.template();

            ExpressionVisitor expressionVisitor = new ExpressionVisitor(this.scopeTable, this.errorReport);
            expressionVisitor.Visit(tree);
        }
    }
}
