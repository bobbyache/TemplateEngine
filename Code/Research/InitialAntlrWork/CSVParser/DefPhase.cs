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
    public class DefPhase : CYMBOLBaseListener
    {
        public ParseTreeProperty<IScope> scopes = new ParseTreeProperty<IScope>();
        public GlobalScope globals;
        IScope currentScope; // define symbols for this scope.

        public override void EnterFile(CYMBOLParser.FileContext context)
        {
            globals = new GlobalScope();
            currentScope = globals;

            base.EnterFile(context);
        }

        public override void ExitFile(CYMBOLParser.FileContext context)
        {
            Console.WriteLine(globals.ToString());
            base.ExitFile(context);
        }

        public override void EnterFunctionDecl(CYMBOLParser.FunctionDeclContext context)
        {
            string name = context.ID().GetText();

            //int typeTokenType = context.type().Start.Type;
            ////int typeTokenType = context.type().Start.GetType()

            //BuiltInTypeSymbol builtInTypeSymbol;
            //switch (typeTokenType)
            //{
            //    case 5: builtInTypeSymbol = new BuiltInTypeSymbol("void"); break;
            //    case 4: builtInTypeSymbol = new BuiltInTypeSymbol("int"); break;
            //    case 3: builtInTypeSymbol = new BuiltInTypeSymbol("float"); break;
            //    default: builtInTypeSymbol = null; break;
            //}
            //IType type = builtInTypeSymbol;

            //CheckSymbols.getType(typeTokenType);

            string tokenText = context.type().Start.Text;
            BuiltInTypeSymbol builtInTypeSymbol = new BuiltInTypeSymbol(tokenText);

            // push the new scope by making new one that points to enclosing scope.
            MethodSymbol function = new MethodSymbol(name, builtInTypeSymbol, currentScope);
            currentScope.Define(function); // Define function in current scope
            saveScope(context, function); // Push: set function's parent to current
            currentScope = function; // Current scope is now function scope

            base.EnterFunctionDecl(context);
        }

        public override void ExitFunctionDecl(CYMBOLParser.FunctionDeclContext context)
        {
            Console.WriteLine(currentScope.ToString());
            currentScope = currentScope.GetEnclosingScope(); // pop scope...
            base.ExitFunctionDecl(context);
        }

        public override void EnterBlock(CYMBOLParser.BlockContext context)
        {
            // push new local scope
            currentScope = new LocalScope(currentScope);
            saveScope(context, currentScope);
            base.EnterBlock(context);
        }

        public override void ExitBlock(CYMBOLParser.BlockContext context)
        {
            // pop
            Console.WriteLine(currentScope.ToString());
            currentScope = currentScope.GetEnclosingScope();
            base.ExitBlock(context);
        }

        public override void ExitFormalParameter(CYMBOLParser.FormalParameterContext context)
        {
            DefineVar(context.type(), context.ID().Symbol);
            base.ExitFormalParameter(context);
        }

        public override void ExitVarDecl(CYMBOLParser.VarDeclContext context)
        {
            DefineVar(context.type(), context.ID().Symbol);
            base.ExitVarDecl(context);
        }

        private void DefineVar(CYMBOLParser.TypeContext typeCtx, IToken nameToken)
        {


            
            


            //int typeTokenType = typeCtx.Start.Type;
            //BuiltInTypeSymbol builtInTypeSymbol;
            //switch (typeTokenType)
            //{
            //    case 5: builtInTypeSymbol = new BuiltInTypeSymbol("void"); break;
            //    case 4: builtInTypeSymbol = new BuiltInTypeSymbol("int"); break;
            //    case 3: builtInTypeSymbol = new BuiltInTypeSymbol("float"); break;
            //    default: builtInTypeSymbol = null; break;
            //}
            //IType type = builtInTypeSymbol;

            string tokenText = typeCtx.Start.Text;
            IType builtInTypeSymbol = new BuiltInTypeSymbol(tokenText);
            VariableSymbol var = new VariableSymbol(nameToken.Text, builtInTypeSymbol);
            currentScope.Define(var);
        }

        private void saveScope(ParserRuleContext ctx, IScope s) { scopes.Put(ctx, s); }
    }
}
