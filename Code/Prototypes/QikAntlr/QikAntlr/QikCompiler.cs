using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using QikAntlr.Antlr;
using CygSoft.Qik.LanguageEngine.Antlr;
using CygSoft.Qik.LanguageEngine.QikControls;
using CygSoft.Qik.LanguageEngine.QikExpressions;
using CygSoft.Qik.LanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine
{
    public class QikCompiler : IQikCompiler
    {
        public IQikControl[] Controls { get; private set; }
        public IQikExpression[] Expressions { get; private set; }

        private ScopeTable scopeTable = new ScopeTable();

        public string[] Symbols
        {
            get { return scopeTable.Symbols; }
        }

        public string[] Placeholders
        {
            get { return scopeTable.Placeholders; }
        }

        public string FindSymbolValue(string symbol)
        {
            return scopeTable.FindSymbol(symbol);
        }

        public string FindOutput(string placeholder)
        {
            return scopeTable.FindPlaceholder(placeholder);
        }

        public string FindTitle(string placeholder)
        {
            return scopeTable.FindTitle(placeholder);
        }

        public void ExecuteScript(string inputData)
        {
            scopeTable.Clear();

            this.Controls = GetControls(inputData);
            this.Expressions = GetExpressions(inputData);
        }

        private IQikControl[] GetControls(string inputData)
        {
            AntlrInputStream inputStream = new AntlrInputStream(inputData);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            IParseTree tree = parser.template();

            QikControlVisitor controlVisitor = new QikControlVisitor(this.scopeTable);
            controlVisitor.Visit(tree);

            IQikControl[] controls = controlVisitor.ControlDictionary.Values.ToArray();

            return controls;
        }

        private IQikExpression[] GetExpressions(string inputData)
        {
            AntlrInputStream inputStream = new AntlrInputStream(inputData);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            IParseTree tree = parser.template();

            QikExpressionVisitor expressionVisitor = new QikExpressionVisitor(this.scopeTable);
            expressionVisitor.Visit(tree);
            //QikControlVisitor controlVisitor = new QikControlVisitor();
            //controlVisitor.Visit(tree);

            return expressionVisitor.Expressions;
        }
    }
}
