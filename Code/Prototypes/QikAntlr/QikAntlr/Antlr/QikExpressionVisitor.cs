using QikAntlr.Antlr;
using QikLanguageEngine.QikExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.Antlr
{
    public class QikExpressionVisitor : QikTemplateBaseVisitor<QikFunction>
    {
        private List<QikExpression> expressions = new List<QikExpression>();

        public QikExpression[] Expressions { get { return this.expressions.ToArray(); } }

        public override QikFunction VisitExprDecl(QikTemplateParser.ExprDeclContext context)
        {
            if (context.concatExpr() != null)
            {
                QikConcatenateFunction concatenateFunc = GetConcatenateFunction(context.concatExpr());
                QikExpression expression = new QikExpression(context.ID().GetText(), concatenateFunc);
                expressions.Add(expression);
            }
            else if (context.expr() != null)
            {
                var expr = context.expr();

                QikFunction result = null;
                if (expr.STRING() != null)
                    result = new QikTextFunction(new QikLiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new QikTextFunction(new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = Visit(expr);

                QikExpression expression = new QikExpression(context.ID().GetText(), result);
                expressions.Add(expression);
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
                    result = new QikLowerCaseFunction(new QikLiteralText(expr.STRING().GetText()));
                else if (expr.ID() != null)
                {
                    result = new QikLowerCaseFunction(new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = new QikLowerCaseFunction(Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                QikFunction result = new QikTextFunction(new QikVariable(context.ID().ToString()));
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
                    result = new QikUpperCaseFunction(new QikLiteralText(expr.STRING().GetText()));

                else if (expr.ID() != null)
                {
                    result = new QikUpperCaseFunction(new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = new QikUpperCaseFunction(Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                QikFunction result = new QikUpperCaseFunction(new QikVariable(context.ID().ToString()));
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
                    result = new QikRemoveSpacesFunction(new QikLiteralText(expr.STRING().GetText()));

                else if (expr.ID() != null)
                {
                    result = new QikRemoveSpacesFunction(new QikVariable(expr.ID().GetText()));
                    return result;
                }
                else
                    result = new QikRemoveSpacesFunction(Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                QikFunction result = new QikRemoveSpacesFunction(new QikVariable(context.ID().ToString()));
                return result;
            }

            return null;
        }

        private QikConcatenateFunction GetConcatenateFunction(QikTemplateParser.ConcatExprContext context)
        {
            QikConcatenateFunction concatenateFunc = new QikConcatenateFunction();

            var concatExprs = context.expr();
            foreach (var concatExpr in concatExprs)
            {
                QikFunction result = null;

                if (concatExpr.STRING() != null)
                    result = new QikTextFunction(new QikLiteralText(concatExpr.STRING().GetText()));

                else if (concatExpr.ID() != null)
                {
                    result = new QikTextFunction(new QikVariable(concatExpr.ID().GetText()));
                }
                else
                    result = Visit(concatExpr);

                concatenateFunc.AddFunction(result);
            }

            return concatenateFunc;
        }
    }
}
