using QikAntlr.Antlr;
using CygSoft.Qik.LanguageEngine.QikExpressions;
using CygSoft.Qik.LanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Antlr
{
    public class QikExpressionVisitor : QikTemplateBaseVisitor<QikFunction>
    {
        private List<QikExpression> expressions = new List<QikExpression>();

        private ScopeTable scopeTable;

        internal QikExpressionVisitor(ScopeTable scopeTable)
        {
            this.scopeTable = scopeTable;
        }

        public QikExpression[] Expressions { get { return this.expressions.ToArray(); } }

        public override QikFunction VisitExprDecl(QikTemplateParser.ExprDeclContext context)
        {
            string id = context.ID().GetText();
            string title = GetExpressionTitle(context);

            if (context.concatExpr() != null)
            {
                QikConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                QikExpression expression = new QikExpression(this.scopeTable, id, title, concatenateFunc);
                expressions.Add(expression);
            }
            else if (context.optExpr() != null)
            {
                var expr = context.optExpr();
                QikFunction ifFunc = VisitOptExpr(context.optExpr());

                QikExpression expression = new QikExpression(this.scopeTable, id, title, ifFunc);
                expressions.Add(expression);
                //expressions.Add(ifFunc);
                //return ifFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                QikFunction result = null;
                if (expr.STRING() != null)
                    result = new QikTextFunction(this.scopeTable, new QikLiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new QikTextFunction(this.scopeTable, new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = Visit(expr);

                QikExpression expression = new QikExpression(this.scopeTable, context.ID().GetText(), title, result);
                expressions.Add(expression);
            }

            return null;
        }

        public override QikFunction VisitOptExpr(QikTemplateParser.OptExprContext context)
        {
            string id = context.ID().GetText();
            QikIfFunction ifFunc = new QikIfFunction(this.scopeTable, id);
            
            foreach (var ifOptContext in context.ifOptExpr())
            {
                QikFunction result = null;
                string text = ifOptContext.STRING().GetText();

                if (ifOptContext.concatExpr() != null)
                {
                    QikConcatenateFunction concatenateFunc = GetConcatenateFunction(ifOptContext.concatExpr());
                    ifFunc.AddFunction(text, concatenateFunc);
                }
                else if (ifOptContext.expr() != null)
                {
                    var expr = ifOptContext.expr();
                    if (expr.STRING() != null)
                    {
                        result = new QikTextFunction(this.scopeTable, new QikLiteralText(expr.STRING().GetText()));
                        ifFunc.AddFunction(text, result);
                    }
                    else if (expr.ID() != null)
                    {
                        result = new QikTextFunction(this.scopeTable, new QikVariable(expr.ID().GetText()));
                        return result;
                    }
                    else
                        ifFunc.AddFunction(text, Visit(expr));
                }
            }

            return ifFunc;
        }

        public override QikFunction VisitCamelCaseFunc(QikTemplateParser.CamelCaseFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                QikConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                QikFunction result = null;

                if (expr.STRING() != null)
                    result = new QikCamelCaseFunction(this.scopeTable, new QikLiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new QikCamelCaseFunction(this.scopeTable, new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = new QikCamelCaseFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                QikFunction result = new QikCamelCaseFunction(this.scopeTable, new QikVariable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        public override QikFunction VisitCurrentDateFunc(QikTemplateParser.CurrentDateFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                QikConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                QikFunction result = null;

                if (expr.STRING() != null)
                    result = new QikCurrentDateFunction(this.scopeTable, new QikLiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new QikCurrentDateFunction(this.scopeTable, new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = new QikCurrentDateFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                QikFunction result = new QikCurrentDateFunction(this.scopeTable, new QikVariable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        public override QikFunction VisitLowerCaseFunc(QikTemplateParser.LowerCaseFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                QikConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                QikFunction result = null;

                if (expr.STRING() != null)
                    result = new QikLowerCaseFunction(this.scopeTable, new QikLiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new QikLowerCaseFunction(this.scopeTable, new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = new QikLowerCaseFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                QikFunction result = new QikLowerCaseFunction(this.scopeTable, new QikVariable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        public override QikFunction VisitUpperCaseFunc(QikTemplateParser.UpperCaseFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                QikConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                QikFunction result = null;

                if (expr.STRING() != null)
                    result = new QikUpperCaseFunction(this.scopeTable, new QikLiteralText(expr.STRING().GetText()));

                else if (expr.ID() != null)
                {
                    result = new QikUpperCaseFunction(this.scopeTable, new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = new QikUpperCaseFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                QikFunction result = new QikUpperCaseFunction(this.scopeTable, new QikVariable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        public override QikFunction VisitRemoveSpacesFunc(QikTemplateParser.RemoveSpacesFuncContext context)
        {
            if (context.concatExpr() != null)
            {
                QikConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                return concatenateFunc;
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                QikFunction result = null;

                if (expr.STRING() != null)
                    result = new QikRemoveSpacesFunction(this.scopeTable, new QikLiteralText(expr.STRING().GetText()));

                else if (expr.ID() != null)
                {
                    result = new QikRemoveSpacesFunction(this.scopeTable, new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = new QikRemoveSpacesFunction(this.scopeTable, Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                QikFunction result = new QikRemoveSpacesFunction(this.scopeTable, new QikVariable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        private QikConcatenateFunction GetConcatenateFunction(QikTemplateParser.ConcatExprContext context)
        {
            QikConcatenateFunction concatenateFunc = new QikConcatenateFunction(this.scopeTable);

            var concatExprs = context.expr();
            foreach (var concatExpr in concatExprs)
            {
                QikFunction result = null;

                if (concatExpr.STRING() != null)
                    result = new QikTextFunction(this.scopeTable, new QikLiteralText(concatExpr.STRING().GetText()));

                else if (concatExpr.ID() != null)
                {
                    result = new QikTextFunction(this.scopeTable, new QikVariable(concatExpr.ID().GetText()));
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
                titleText = QikCommon.StripOuterQuotes(context.titleArg().STRING().GetText());
            }
            return titleText;
        }
    }
}
