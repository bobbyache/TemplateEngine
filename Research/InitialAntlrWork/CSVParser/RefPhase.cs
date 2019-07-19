using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using CSVParsing.ANTLR.SymbolTables;

namespace CSVParsing
{
    public class RefPhase : CYMBOLBaseListener
    {
        ParseTreeProperty<IScope> scopes;
        GlobalScope globals;
        IScope currentScope; // resolve symbols starting in this scope

        public RefPhase(GlobalScope globals, ParseTreeProperty<IScope> scopes)
        {
            this.scopes = scopes;
            this.globals = globals;
        }

        public override void EnterFile(CYMBOLParser.FileContext context)
        {
            currentScope = globals;
            base.EnterFile(context);
        }

        public override void EnterFunctionDecl(CYMBOLParser.FunctionDeclContext context)
        {
            currentScope = scopes.Get(context);
            base.EnterFunctionDecl(context);
        }

        public override void ExitFunctionDecl(CYMBOLParser.FunctionDeclContext context)
        {
            currentScope = currentScope.GetEnclosingScope();
            base.ExitFunctionDecl(context);
        }

        public override void EnterBlock(CYMBOLParser.BlockContext context)
        {
            currentScope = scopes.Get(context);
            base.EnterBlock(context);
        }

        public override void ExitBlock(CYMBOLParser.BlockContext context)
        {
            currentScope = currentScope.GetEnclosingScope();
            base.ExitBlock(context);
        }

        public override void ExitVar(CYMBOLParser.VarContext context)
        {
            string name = context.ID().Symbol.Text;
            Symbol var = currentScope.Resolve(name);
            if (var == null)
                CheckSymbols.Error(context.ID().Symbol, "no such variable: " + name);

            if (var is MethodSymbol)
                CheckSymbols.Error(context.ID().Symbol, name + " is not a variable");

            base.ExitVar(context);
        }

        public override void ExitCall(CYMBOLParser.CallContext context)
        {
            // can only handle f(...) not expr(...)
            string funcName = context.ID().GetText();
            Symbol meth = currentScope.Resolve(funcName);
            if (meth == null)
                CheckSymbols.Error(context.ID().Symbol, "no such function: " + funcName);

            if (meth is VariableSymbol)
                CheckSymbols.Error(context.ID().Symbol, funcName + " is not a function");

            base.ExitCall(context);
        }
    }
}
