using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CSVParsing
{
    public class CsvLoader
    {
        public List<Dictionary<string, string>> Load(string inputData)
        {
            AntlrInputStream stream = new AntlrInputStream(inputData);

            CSVLexer lexer = new CSVLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CSVParser parser = new CSVParser(tokens);
            parser.BuildParseTree = true;
            IParseTree tree = parser.file();

            ParseTreeWalker walker = new ParseTreeWalker();
            Loader loader = new Loader();
            walker.Walk(loader, tree);

            //Console.WriteLine(loader.Rows);
            //Console.WriteLine(tree.ToStringTree());

            //Antlr4.Runtime.

            return loader.Rows;
        }

        public string JsonToXml(string jsonData)
        {
            AntlrInputStream stream = new AntlrInputStream(jsonData);

            JSONLexer lexer = new JSONLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            JSONParser parser = new JSONParser(tokens);
            parser.BuildParseTree = true;
            IParseTree tree = parser.json();

            ParseTreeWalker walker = new ParseTreeWalker();
            //Loader loader = new Loader();
            XmlEmitter emitter = new XmlEmitter();
            
            walker.Walk(emitter, tree);

            string xml = emitter.Xml();
            return xml;
            //Console.WriteLine(loader.Rows);
            //Console.WriteLine(tree.ToStringTree());

            //return loader.Rows;
        }


        public string GetCymbolFunctions(string cymbolCode)
        {
            AntlrInputStream stream = new AntlrInputStream(cymbolCode);

            CYMBOLLexer lexer = new CYMBOLLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CYMBOLParser parser = new CYMBOLParser(tokens);
            parser.BuildParseTree = true;
            IParseTree tree = parser.file(); // in this case "file" comes from the root rule in CYMBOL.g4

            ParseTreeWalker walker = new ParseTreeWalker();
            FunctionListener funcListener = new FunctionListener();

            walker.Walk(funcListener, tree);

            Console.WriteLine(funcListener.graph.ToString());
            Console.WriteLine(funcListener.graph.ToDot());

            return string.Empty;
        }

        public void CheckAllSymbols(string cymbolCode)
        {
            AntlrInputStream stream = new AntlrInputStream(cymbolCode);

            CYMBOLLexer lexer = new CYMBOLLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CYMBOLParser parser = new CYMBOLParser(tokens);
            parser.BuildParseTree = true;
            IParseTree tree = parser.file(); // in this case "file" comes from the root rule in CYMBOL.g4

            ParseTreeWalker walker = new ParseTreeWalker();
            CheckSymbols checkSymbols = new CSVParsing.CheckSymbols();
            checkSymbols.Process(cymbolCode, new string[0], string.Empty);

            string text = CheckSymbols.builder.ToString();
        }
    }
}
