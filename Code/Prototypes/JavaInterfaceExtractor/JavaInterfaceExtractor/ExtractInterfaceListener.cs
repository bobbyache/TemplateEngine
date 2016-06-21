using Antlr4.Runtime;
using JavaInterfaceExtractor.ANTLR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaInterfaceExtractor
{
    public class ExtractInterfaceListener : JavaBaseListener
    {
        private ITokenStream tokenStream;
        private StringBuilder interfaceBuilder;

        public string Interface
        {
            get
            {
                if (interfaceBuilder != null)
                {
                    return interfaceBuilder.ToString();
                }
                return "";
            }
        }

        public ExtractInterfaceListener(ITokenStream tokenStream)
        {
            this.tokenStream = tokenStream;
            this.interfaceBuilder = new StringBuilder();
        }

        public override void EnterImportDeclaration(JavaParser.ImportDeclarationContext context)
        {

            System.Diagnostics.Debug.WriteLine("import " + context.qualifiedName().GetText() + ";");
            interfaceBuilder.AppendLine("import " + context.qualifiedName().GetText() + ";");
            string test = tokenStream.GetText(context); // simply prints out the text matched by the entire rule
                                                        // which is the same as for what you did above... could
                                                        // just as well just return this statement.
        }

        public override void EnterClassDeclaration(JavaParser.ClassDeclarationContext context)
        {
            System.Diagnostics.Debug.WriteLine("interface I" + context.Identifier() + " {");
            interfaceBuilder.AppendLine("interface I" + context.Identifier() + " {");
        }

        public override void ExitClassDeclaration(JavaParser.ClassDeclarationContext context)
        {
            System.Diagnostics.Debug.WriteLine("}");
            interfaceBuilder.AppendLine("}");
        }

        public override void EnterMethodDeclaration(JavaParser.MethodDeclarationContext context)
        {
            // need parser to get tokens
            string type = "void";
            if (context.type() != null)
            {
                type = tokenStream.GetText(context.type());
            }
            string args = tokenStream.GetText(context.formalParameters());
            System.Diagnostics.Debug.WriteLine("\t" + type + context.Identifier() + args + ";");
            interfaceBuilder.AppendLine("\t" + type + context.Identifier() + args + ";");
        }

        public override void VisitErrorNode(Antlr4.Runtime.Tree.IErrorNode node)
        {
            base.VisitErrorNode(node);
        }
    }
}
