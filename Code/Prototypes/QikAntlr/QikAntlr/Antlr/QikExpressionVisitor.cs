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
                    result = new QikTextFunction(expr.STRING().GetText());
                else if (expr.ID() != null)
                    // ****************************************************************************************
                    // ID/Symbol still needs to be handled !!!!!!!!!!
                    // @testing = expression { return @Hello + @Goodbye; };
                    // ****************************************************************************************
                    return null;
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
                    result = new QikLowerCaseFunction(expr.STRING().GetText());
                else if (expr.ID() != null)
                    // ****************************************************************************************
                    // ID/Symbol still needs to be handled !!!!!!!!!!
                    // @testing = expression { return @Hello + @Goodbye; };
                    // ****************************************************************************************
                    return null;
                else
                    result = new QikLowerCaseFunction(Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                // ****************************************************************************************
                // ID/Symbol still needs to be handled !!!!!!!!!!
                // @testing = expression { return @Hello + @Goodbye; };
                // ****************************************************************************************
                return null;
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
                    result = new QikUpperCaseFunction(expr.STRING().GetText());
                else if (expr.ID() != null)
                    // ****************************************************************************************
                    // ID/Symbol still needs to be handled !!!!!!!!!!
                    // @testing = expression { return @Hello + @Goodbye; };
                    // ****************************************************************************************
                    return null;
                else
                    result = new QikUpperCaseFunction(Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                // ****************************************************************************************
                // ID/Symbol still needs to be handled !!!!!!!!!!
                // @testing = expression { return @Hello + @Goodbye; };
                // ****************************************************************************************
                return null;
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
                    result = new QikRemoveSpacesFunction(expr.STRING().GetText());
                else if (expr.ID() != null)
                    // ****************************************************************************************
                    // ID/Symbol still needs to be handled !!!!!!!!!!
                    // @testing = expression { return @Hello + @Goodbye; };
                    // ****************************************************************************************
                    return null;
                else
                    result = new QikRemoveSpacesFunction(Visit(expr));

                return result;
            }
            else if (context.ID() != null)
            {
                // ****************************************************************************************
                // ID/Symbol still needs to be handled !!!!!!!!!!
                // @testing = expression { return @Hello + @Goodbye; };
                // ****************************************************************************************
                return null;
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
                    result = new QikTextFunction(concatExpr.STRING().GetText());
                else if (concatExpr.ID() != null)
                    // ****************************************************************************************
                    // ID/Symbol still needs to be handled !!!!!!!!!!
                    // @testing = expression { return @Hello + @Goodbye; };
                    // ****************************************************************************************
                    return null;
                else
                    result = Visit(concatExpr);

                concatenateFunc.AddFunction(result);
            }

            return concatenateFunc;
        }
    }
}
