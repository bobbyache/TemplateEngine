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
        public event EventHandler BeforeCompile;
        public event EventHandler AfterCompile;

        public event EventHandler BeforeInput;
        public event EventHandler AfterInput;

        private GlobalTable scopeTable = new GlobalTable();

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
            if (BeforeCompile != null)
                BeforeCompile(this, new EventArgs());

            scopeTable.Clear();

            GetControls(scriptText);
            GetExpressions(scriptText);

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

        private void GetControls(string scriptText)
        {
            AntlrInputStream inputStream = new AntlrInputStream(scriptText);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            IParseTree tree = parser.template();

            UserInputVisitor controlVisitor = new UserInputVisitor(this.scopeTable);
            controlVisitor.Visit(tree);
        }

        private void GetExpressions(string scriptText)
        {
            AntlrInputStream inputStream = new AntlrInputStream(scriptText);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            IParseTree tree = parser.template();

            ExpressionVisitor expressionVisitor = new ExpressionVisitor(this.scopeTable);
            expressionVisitor.Visit(tree);
        }
    }
}
