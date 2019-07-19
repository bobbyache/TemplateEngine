using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using JavaInterfaceExtractor.ANTLR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaInterfaceExtractor
{
    public class Extractor
    {
        public string ExtractInterface(string filePath)
        {
            string input = File.ReadAllText(filePath);

            AntlrInputStream inputStream = new AntlrInputStream(input);
            JavaLexer lexer = new JavaLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            JavaParser parser = new JavaParser(tokens);

            IParseTree tree = parser.compilationUnit();

            ParseTreeWalker walker = new ParseTreeWalker();
            ExtractInterfaceListener extractor = new ExtractInterfaceListener(tokens);
            walker.Walk(extractor, tree);

            return extractor.Interface;
        }
    }
}
