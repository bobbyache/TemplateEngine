using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Scope;
using CygSoft.Qik.LanguageEngine.Symbols;
using QikAntlr.Antlr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Antlr
{
    internal class ExpressionVisitor : QikTemplateBaseVisitor<BaseFunction>
    {
        private GlobalTable scopeTable;

        internal ExpressionVisitor(GlobalTable scopeTable)
        {
            this.scopeTable = scopeTable;
        }

        public override BaseFunction VisitExprDecl(QikTemplateParser.ExprDeclContext context)
        {
            string id = context.VARIABLE().GetText();

            SymbolArguments symbolArguments = new SymbolArguments();
            symbolArguments.Process(context.declArgs());

            if (context.concatExpr() != null)
            {
                ConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                ExpressionSymbol expression = 
                    new ExpressionSymbol(id, symbolArguments.Title, symbolArguments.Description, 
                        symbolArguments.IsPlaceholder, symbolArguments.IsVisibleToEditor, concatenateFunc);
                scopeTable.AddSymbol(expression);
            }
            else if (context.optExpr() != null)
            {
                var expr = context.optExpr();
                BaseFunction ifFunc = VisitOptExpr(context.optExpr());

                ExpressionSymbol expression = new ExpressionSymbol(id, symbolArguments.Title, symbolArguments.Description, 
                    symbolArguments.IsPlaceholder, symbolArguments.IsVisibleToEditor, ifFunc);
                scopeTable.AddSymbol(expression);
            }
            else if (context.expr() != null)
            {
                BaseFunction function = VisitExpr(context.expr());
                ExpressionSymbol expression = new ExpressionSymbol(id, symbolArguments.Title, symbolArguments.Description,
                    symbolArguments.IsPlaceholder, symbolArguments.IsVisibleToEditor, function);
                scopeTable.AddSymbol(expression);
            }

            return null;
        }

        public override BaseFunction VisitOptExpr(QikTemplateParser.OptExprContext context)
        {
            string id = context.VARIABLE().GetText();
            IfDecissionFunction ifFunc = new IfDecissionFunction(this.scopeTable, id);

            foreach (var ifOptContext in context.ifOptExpr())
            {
                string text = ifOptContext.STRING().GetText();

                if (ifOptContext.concatExpr() != null)
                {
                    ConcatenateFunction concatenateFunc = GetConcatenateFunction(ifOptContext.concatExpr());
                    ifFunc.AddFunction(text, concatenateFunc);
                }
                else if (ifOptContext.expr() != null)
                {
                    BaseFunction function = VisitExpr(ifOptContext.expr());
                    ifFunc.AddFunction(text, function);
                }
            }

            return ifFunc;
        }

        public override BaseFunction VisitFunc(QikTemplateParser.FuncContext context)
        {
            BaseFunction func = null;

            if (context.IDENTIFIER() != null)
            {
                string funcIdentifier = context.IDENTIFIER().GetText();
                List<BaseFunction> functionArguments = CreateArguments(context.funcArg());

                switch (funcIdentifier)
                {
                    case "camelCase":
                        CamelCaseFunction camelCaseFunc = new CamelCaseFunction(scopeTable, functionArguments);
                        func = camelCaseFunc;
                        break;
                    case "currentDate":
                        CurrentDateFunction currentDateFunc = new CurrentDateFunction(scopeTable, functionArguments);
                        func = currentDateFunc;
                        break;
                    case "lowerCase":
                        LowerCaseFunction lowerCaseFunc = new LowerCaseFunction(scopeTable, functionArguments);
                        func = lowerCaseFunc;
                        break;
                    case "upperCase":
                        UpperCaseFunction upperCaseFunc = new UpperCaseFunction(scopeTable, functionArguments);
                        func = upperCaseFunc;
                        break;
                    case "removeSpaces":
                        RemoveSpacesFunction removeSpacesFunc = new RemoveSpacesFunction(scopeTable, functionArguments);
                        func = removeSpacesFunc;
                        break;
                    case "indentLine":
                        IndentFunction indentFunc = new IndentFunction(scopeTable, functionArguments);
                        func = indentFunc;
                        break;
                    default:
                        throw new NotSupportedException(string.Format("Function \"{0}\" is not supported in this context.", funcIdentifier));
                }
            }
            return func;
        }

        public override BaseFunction VisitExpr(QikTemplateParser.ExprContext context)
        {
            if (context.STRING() != null)
                return new LiteralTextFunction(scopeTable, Common.StripOuterQuotes(context.STRING().GetText()));

            else if (context.VARIABLE() != null)
                return new VariableFunction(scopeTable, context.VARIABLE().GetText());

            else if (context.CONST() != null)
            {
                string constantText = context.CONST().GetText();
                if (constantText == "NEWLINE")
                    return new NewlineFunction();
                else
                    return new ConstantFunction(scopeTable, context.CONST().GetText());
            }

            else if (context.INT() != null)
                return new IntegerFunction(scopeTable, context.INT().GetText());

            else if (context.FLOAT() != null)
                return new FloatFunction(scopeTable, context.FLOAT().GetText());

            // recurse...
            else if (context.func() != null)
                return VisitFunc(context.func());

            else
                return null;
        }

        private List<BaseFunction> CreateArguments(IReadOnlyList<QikTemplateParser.FuncArgContext> funcArgs)
        {
            List<BaseFunction> functionArguments = new List<BaseFunction>();

            foreach (QikTemplateParser.FuncArgContext funcArg in funcArgs)
            {
                QikTemplateParser.ConcatExprContext concatExpr = funcArg.concatExpr();
                QikTemplateParser.ExprContext expr = funcArg.expr();

                if (concatExpr != null)
                {
                    ConcatenateFunction concatenateFunc = GetConcatenateFunction(concatExpr);
                    functionArguments.Add(concatenateFunc);
                }
                else if (expr != null)
                {
                    BaseFunction function = VisitExpr(expr);
                    functionArguments.Add(function);
                }
            }
            return functionArguments;
        }

        private ConcatenateFunction GetConcatenateFunction(QikTemplateParser.ConcatExprContext context)
        {
            ConcatenateFunction concatenateFunc = new ConcatenateFunction(this.scopeTable);

            IReadOnlyList<QikTemplateParser.ExprContext> expressions = context.expr();

            foreach (QikTemplateParser.ExprContext expr in expressions)
            {
                BaseFunction result = VisitExpr(expr);
                concatenateFunc.AddFunction(result);
            }

            return concatenateFunc;
        }
    }
}
