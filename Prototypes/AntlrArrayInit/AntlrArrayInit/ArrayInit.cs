using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrArrayInit
{
    public class ArrayInit
    {
        public string TreeString(string inputData)
        {
            AntlrInputStream stream = new AntlrInputStream(inputData);
            ArrayInitLexer lexer = new ArrayInitLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            ArrayInitParser parser = new ArrayInitParser(tokens);
            parser.BuildParseTree = true;

            IParseTree tree = parser.init();

            // tree.GetText(); <--- returns the text that was parsed into the tree.
            return tree.ToStringTree();
        }

        public string ConvertToUnicode(string inputData)
        {
            AntlrInputStream stream = new AntlrInputStream(inputData);
            ArrayInitLexer lexer = new ArrayInitLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            ArrayInitParser parser = new ArrayInitParser(tokens);
            parser.BuildParseTree = true;

            IParseTree tree = parser.init();

            ShortToUnicodeString conversionListener = new ShortToUnicodeString();
            ParseTreeWalker walker = new ParseTreeWalker();
            walker.Walk(conversionListener, tree);

            return conversionListener.OutputText;
        }
    }
}
