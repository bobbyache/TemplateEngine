using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpressions
{
    public class Expressions
    {
        public string GetTreeToString(string filePath)
        {
            string input = File.ReadAllText(filePath);

            // also accepts streams.
            AntlrInputStream inputStream = new AntlrInputStream(input);
            ExprLexer lexer = new ExprLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            ExprParser parser = new ExprParser(tokens);
            IParseTree tree = parser.prog();    // parse; start at prog.

            return tree.ToStringTree();
        }

        public string ProcessVisitor(string filePath)
        {
            string input = File.ReadAllText(filePath);
            AntlrInputStream inputStream = new AntlrInputStream(input);
            LabeledExprLexer lexer = new LabeledExprLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            LabeledExprParser parser = new LabeledExprParser(tokens);

            IParseTree tree = parser.prog();

            EvalVisitor evalVisitor = new EvalVisitor();
            evalVisitor.Visit(tree);

            return string.Join(",", evalVisitor.Calculations);
        }
    }
}
