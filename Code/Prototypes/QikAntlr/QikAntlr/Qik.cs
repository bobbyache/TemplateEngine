using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using QikAntlr.Antlr;
using QikLanguageEngine.Antlr;
using QikLanguageEngine.QikControls;
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
        public QikControl[] GetControls(string filePath)
        {
            string input = File.ReadAllText(filePath);

            AntlrInputStream inputStream = new AntlrInputStream(input);
            QikTemplateLexer lexer = new QikTemplateLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            QikTemplateParser parser = new QikTemplateParser(tokens);

            IParseTree tree = parser.template();

            QikControlVisitor controlVisitor = new QikControlVisitor();
            controlVisitor.Visit(tree);

            QikControl[] controls = controlVisitor.ControlDictionary.Values.ToArray();

            return controls;
        }
    }
}
