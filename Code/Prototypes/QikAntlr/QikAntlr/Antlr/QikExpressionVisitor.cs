using QikAntlr.Antlr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.Antlr
{
    public class QikExpressionVisitor : QikTemplateBaseVisitor<string>
    {
        public override string VisitLowerCaseFunc(QikTemplateParser.LowerCaseFuncContext context)
        {
            if (context.ID() != null)
            {
                string lowerCaseText = context.ID().GetText();
                return lowerCaseText;
            }
            else if (context.STRING() != null)
            {
                string lowerCaseText = context.STRING().GetText().ToLower();
                return lowerCaseText;
            }
            else if (context.func() != null)
            {
                string funcText = context.func().GetText();
                return funcText;
            }
            else
                return null;
        }

        public override string VisitUpperCaseFunc(QikTemplateParser.UpperCaseFuncContext context)
        {
            if (context.ID() != null)
            {
                string upperCaseText = context.ID().GetText();
                return upperCaseText;
            }
            else if (context.STRING() != null)
            {
                string upperCaseText = context.STRING().GetText().ToUpper();
                return upperCaseText;
            }
            else if (context.func() != null)
            {
                string funcText = context.func().GetText();
                return funcText;
            }
            else
                return null;
        }

        public override string VisitRemoveSpacesFunc(QikTemplateParser.RemoveSpacesFuncContext context)
        {
            if (context.ID() != null)
            {
                string noSpaceText = context.ID().GetText();
                return noSpaceText;
            }
            else if (context.STRING() != null)
            {
                string noSpaceText = context.STRING().GetText().Replace(" ", "");
                return noSpaceText;
            }
            else if (context.func() != null)
            {
                string funcText = context.func().GetText();
                return funcText;
            }
            else
                return null;
        }
    }
}
