using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParsing
{
    public class FunctionListener : CYMBOLBaseListener
    {
        public Graph graph = new Graph();
        private string currentFunctionName = null;

        public override void EnterFunctionDecl(CYMBOLParser.FunctionDeclContext context)
        {
            currentFunctionName = context.ID().GetText();
            graph.nodes.Add(currentFunctionName);
            base.EnterFunctionDecl(context);
        }

        public override void ExitCall(CYMBOLParser.CallContext context)
        {
            string funcName = context.ID().GetText();
            graph.Edge(currentFunctionName, funcName);
            base.ExitCall(context);
        }

        public override void ExitInt(CYMBOLParser.IntContext context)
        {
            base.ExitInt(context);
        }
    }
}
