using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using QikAntlr.Antlr;
using QikLanguageEngine.Antlr;
using QikLanguageEngine.QikControls;
using QikLanguageEngine.QikExpressions;
using QikLanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine
{
    public class Qik
    {
        //public QikControl[] GetControls(string filePath)
        //{
        //    string input = File.ReadAllText(filePath);

        //    AntlrInputStream inputStream = new AntlrInputStream(input);
        //    QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
        //    CommonTokenStream tokens = new CommonTokenStream(lexer);
        //    QikTemplateParser parser = new QikTemplateParser(tokens);

        //    IParseTree tree = parser.template();

        //    QikControlVisitor controlVisitor = new QikControlVisitor();
        //    controlVisitor.Visit(tree);

        //    QikControl[] controls = controlVisitor.ControlDictionary.Values.ToArray();

        //    return controls;
        //}

        public QikControl[] Controls { get; private set; }
        public QikExpression[] Expressions { get; private set; }

        public void ExecuteScript(string inputData)
        {
            ScopeTable.Clear();

            ScopeTable.Add("@goodbye", "GOODBYE OLD BOY, WELL DONE!");

            QikControl[] controls = GetControls(inputData);
            foreach (QikControl control in controls)
            {
                if (control.DefaultValue != null)
                    ScopeTable.Add(control.ControlId, control.DefaultValue);
                else
                    ScopeTable.Add(control.ControlId);
            }
            this.Controls = controls;

            QikExpression[] expressions = GetExpressions(inputData);
            foreach (QikExpression expression in expressions)
                ScopeTable.Add(expression.Symbol);
            this.Expressions = expressions;
        }

        private QikControl[] GetControls(string inputData)
        {
            AntlrInputStream inputStream = new AntlrInputStream(inputData);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            IParseTree tree = parser.template();

            QikControlVisitor controlVisitor = new QikControlVisitor();
            controlVisitor.Visit(tree);

            QikControl[] controls = controlVisitor.ControlDictionary.Values.ToArray();

            return controls;
        }

        private QikExpression[] GetExpressions(string inputData)
        {
            AntlrInputStream inputStream = new AntlrInputStream(inputData);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            IParseTree tree = parser.template();

            QikExpressionVisitor expressionVisitor = new QikExpressionVisitor();
            expressionVisitor.Visit(tree);
            QikControlVisitor controlVisitor = new QikControlVisitor();
            controlVisitor.Visit(tree);

            return expressionVisitor.Expressions;
        }
    }
}
