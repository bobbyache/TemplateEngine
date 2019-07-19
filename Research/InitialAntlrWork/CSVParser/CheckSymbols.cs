using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CSVParsing.ANTLR.SymbolTables;

namespace CSVParsing
{
    public class CheckSymbols
    {
        // NB. You'll have to look at the Java Source to try and understand what this does. Don't think it's important
        // because currently we pick up the "variable" or symbol as the .Text from context.ID().Symbol.Text in
        // ExitVar "RefPhase" and "DefPhase" classes.

        //public static Symbol.TypeEnum GetType(int tokenType)
        //{
        //    switch (tokenType)
        //    {
        //        case CYMBOLParser.K_VOID: return Symbol.TypeEnum.tVOID;
        //        case CYMBOLParser.K_INT: return Symbol.TypeEnum.tINT;
        //        case CYMBOLParser.K_FLOAT: return Symbol.TypeEnum.tFLOAT;
        //    }
        //    return CYMBOLParser.tINVALID;
        //}

        public static StringBuilder builder = new StringBuilder();

        public static void Error(IToken token, string msg)
        {
            // Looked for getCharPositionInLine as documented in the Java code
            // source, but this this property doesn't exist on the token in the C# code. It appears to map to
            // "Column" which always returns the index of the trimmed result, so the white space before is
            // ignored. This is still workabled, we only really have to show that the error is on line x.
            Console.WriteLine("line {0}:{1} {2}", token.Line, token.Column, msg);
            builder.AppendLine(string.Format("line {0}:{1} {2}", token.Line, token.Column, msg));
            System.Diagnostics.Debug.WriteLine(builder.ToString());
            string text = builder.ToString();
        }

        public void Process(string cymbolCode, string[] args, string msg)
        {
            builder.Clear();

            Antlr4.Runtime.AntlrInputStream input = new Antlr4.Runtime.AntlrInputStream(cymbolCode);
            CYMBOLLexer lexer = new CYMBOLLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CYMBOLParser parser = new CYMBOLParser(tokens);
            parser.BuildParseTree = true;
            
            // in this case "file" comes from the root rule in CYMBOL.g4
            IParseTree tree = parser.file(); 

            ParseTreeWalker walker = new ParseTreeWalker();

            DefPhase defPhase = new DefPhase();
            walker.Walk(defPhase, tree);

            RefPhase refPhase = new RefPhase(defPhase.globals, defPhase.scopes);
            walker.Walk(refPhase, tree);
        }
    }
}
