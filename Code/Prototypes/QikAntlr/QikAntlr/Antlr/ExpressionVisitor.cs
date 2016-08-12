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
    internal class ExpressionVisitor :  QikTemplateBaseVisitor<BaseFunction>
    {
        private GlobalTable scopeTable;

        internal ExpressionVisitor(GlobalTable scopeTable)
        {
            this.scopeTable = scopeTable;
        }

        public override BaseFunction VisitExprDecl(QikTemplateParser.ExprDeclContext context)
        {
            string id = context.ID().GetText();
            string title = GetExpressionTitle(context);

            if (context.concatExpr() != null)
            {
                ConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                ExpressionSymbol expression = new ExpressionSymbol(id, title, concatenateFunc);
                scopeTable.AddSymbol(expression);
            }
            else if (context.optExpr() != null)
            {
                var expr = context.optExpr();
                BaseFunction ifFunc = VisitOptExpr(context.optExpr());

                ExpressionSymbol expression = new ExpressionSymbol(id, title, ifFunc);
                scopeTable.AddSymbol(expression);
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                BaseFunction result = null;
                if (expr.STRING() != null)
                    result = new TextFunction(this.scopeTable, new LiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new TextFunction(this.scopeTable, new Variable(expr.ID().GetText()));
                    return result;
                }
                else if (expr.NEWLINE() != null)
                {
                    result = new NewlineFunction();
                }
                else
                    result = Visit(expr);

                ExpressionSymbol expression = new ExpressionSymbol(context.ID().GetText(), title, result);
                scopeTable.AddSymbol(expression);
            }

            return null;
        }

        public override BaseFunction VisitOptExpr(QikTemplateParser.OptExprContext context)
        {
            string id = context.ID().GetText();
            IfDecissionFunction ifFunc = new IfDecissionFunction(this.scopeTable, id);
            
            foreach (var ifOptContext in context.ifOptExpr())
            {
                BaseFunction result = null;
                string text = ifOptContext.STRING().GetText();

                if (ifOptContext.concatExpr() != null)
                {
                    ConcatenateFunction concatenateFunc = GetConcatenateFunction(ifOptContext.concatExpr());
                    ifFunc.AddFunction(text, concatenateFunc);
                }
                else if (ifOptContext.expr() != null)
                {
                    var expr = ifOptContext.expr();
                    if (expr.STRING() != null)
                    {
                        result = new TextFunction(this.scopeTable, new LiteralText(expr.STRING().GetText()));
                        ifFunc.AddFunction(text, result);
                    }
                    else if (expr.ID() != null)
                    {
                        result = new TextFunction(this.scopeTable, new Variable(expr.ID().GetText()));
                        return result;
                    }
                    else if (expr.NEWLINE() != null)
                    {
                        result = new NewlineFunction();
                    }
                    else
                        ifFunc.AddFunction(text, Visit(expr));
                }
            }

            return ifFunc;
        }

        public override BaseFunction VisitCamelCaseFunc(QikTemplateParser.CamelCaseFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                ConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                BaseFunction result = null;

                if (expr.STRING() != null)
                    result = new CamelCaseFunction(this.scopeTable, new LiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new CamelCaseFunction(this.scopeTable, new Variable(expr.ID().GetText()));
                    return result;
                }
                else if (expr.NEWLINE() != null)
                {
                    result = new NewlineFunction();
                }
                else
                    result = new CamelCaseFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                BaseFunction result = new CamelCaseFunction(this.scopeTable, new Variable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        public override BaseFunction VisitCurrentDateFunc(QikTemplateParser.CurrentDateFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                ConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                BaseFunction result = null;

                if (expr.STRING() != null)
                    result = new CurrentDateFunction(this.scopeTable, new LiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new CurrentDateFunction(this.scopeTable, new Variable(expr.ID().GetText()));
                    return result;
                }
                else if (expr.NEWLINE() != null)
                {
                    result = new NewlineFunction();
                }
                else
                    result = new CurrentDateFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                BaseFunction result = new CurrentDateFunction(this.scopeTable, new Variable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        public override BaseFunction VisitLowerCaseFunc(QikTemplateParser.LowerCaseFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                ConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                BaseFunction result = null;

                if (expr.STRING() != null)
                    result = new LowerCaseFunction(this.scopeTable, new LiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new LowerCaseFunction(this.scopeTable, new Variable(expr.ID().GetText()));
                    return result;
                }
                else if (expr.NEWLINE() != null)
                {
                    result = new NewlineFunction();
                }
                else
                    result = new LowerCaseFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                BaseFunction result = new LowerCaseFunction(this.scopeTable, new Variable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        public override BaseFunction VisitUpperCaseFunc(QikTemplateParser.UpperCaseFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                ConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                BaseFunction result = null;

                if (expr.STRING() != null)
                    result = new UpperCaseFunction(this.scopeTable, new LiteralText(expr.STRING().GetText()));

                else if (expr.ID() != null)
                {
                    result = new UpperCaseFunction(this.scopeTable, new Variable(expr.ID().GetText()));
                    return result;
                }
                else if (expr.NEWLINE() != null)
                {
                    result = new NewlineFunction();
                }
                else
                    result = new UpperCaseFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                BaseFunction result = new UpperCaseFunction(this.scopeTable, new Variable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        public override BaseFunction VisitRemoveSpacesFunc(QikTemplateParser.RemoveSpacesFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                ConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                BaseFunction result = null;

                if (expr.STRING() != null)
                    result = new RemoveSpacesFunction(this.scopeTable, new LiteralText(expr.STRING().GetText()));

                else if (expr.ID() != null)
                {
                    result = new RemoveSpacesFunction(this.scopeTable, new Variable(expr.ID().GetText()));
                    return result;
                }
                else if (expr.NEWLINE() != null)
                {
                    result = new NewlineFunction();
                }
                else
                    result = new RemoveSpacesFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                BaseFunction result = new RemoveSpacesFunction(this.scopeTable, new Variable(context.ID().ToString()));
                return result;
            }

            return null;
        }


        public override BaseFunction VisitIndentFunc(QikTemplateParser.IndentFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                ConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                BaseFunction result = null;

                if (expr.STRING() != null)
                    result = new IndentFunction(this.scopeTable, new LiteralText(expr.STRING().GetText()), context.INDENT().GetText());

                else if (expr.ID() != null)
                {
                    result = new IndentFunction(this.scopeTable, new Variable(expr.ID().GetText()), context.INDENT().GetText());
                    return result;
                }
                else if (expr.NEWLINE() != null)
                {
                    result = new NewlineFunction();
                }
                else
                    result = new IndentFunction(this.scopeTable, Visit(expr), context.INDENT().GetText());

                return result;
            }
            else if (context.ID() != null)
            {
                BaseFunction result = new IndentFunction(this.scopeTable, new Variable(context.ID().ToString()), context.INDENT().GetText());
                return result;
            }

            return null;
        }

        private ConcatenateFunction GetConcatenateFunction(QikTemplateParser.ConcatExprContext context)
        {
            ConcatenateFunction concatenateFunc = new ConcatenateFunction(this.scopeTable);

            var concatExprs = context.expr();
            foreach (var concatExpr in concatExprs)
            {
                BaseFunction result = null;

                if (concatExpr.STRING() != null)
                    result = new TextFunction(this.scopeTable, new LiteralText(concatExpr.STRING().GetText()));

                else if (concatExpr.ID() != null)
                {
                    result = new TextFunction(this.scopeTable, new Variable(concatExpr.ID().GetText()));
                }
                else if (concatExpr.NEWLINE() != null)
                {
                    result = new NewlineFunction();
                }
                else
                    result = Visit(concatExpr);

                concatenateFunc.AddFunction(result);
            }

            return concatenateFunc;
        }

        private string GetExpressionTitle(QikTemplateParser.ExprDeclContext context)
        {
            string titleText = null;
            if (context.titleArg() != null)
            {
                titleText = Common.StripOuterQuotes(context.titleArg().STRING().GetText());
            }
            return titleText;
        }
    }
}
