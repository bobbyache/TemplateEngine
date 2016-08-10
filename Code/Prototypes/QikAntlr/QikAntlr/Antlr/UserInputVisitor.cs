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
    internal class UserInputVisitor : QikTemplateBaseVisitor<string>
    {
        private GlobalTable scopeTable;

        internal UserInputVisitor(GlobalTable scopeTable)
        {
            this.scopeTable = scopeTable;
        }

        public override string VisitTextBox(QikTemplateParser.TextBoxContext context)
        {
            string controlId = context.ID().GetText();

            string titleText = GetTextBoxTitle(context);
            string defaultText = GetTextBoxDefaultText(context);

            TextInputSymbol textInputSymbol = new TextInputSymbol(controlId, titleText, defaultText);
            scopeTable.AddSymbol(textInputSymbol);

            return base.VisitTextBox(context);
        }

        public override string VisitOptionBox(QikTemplateParser.OptionBoxContext context)
        {
            string controlId = context.ID().GetText();
            string defaultId = GetOptionBoxDefaultId(context);
            string titleText = GetOptionBoxTitle(context);

            OptionInputSymbol optionInputSymbol = new OptionInputSymbol(controlId, titleText, defaultId);

            foreach (QikTemplateParser.SingleOptionContext optionContext in context.optionsBody().singleOption())
            {
                optionInputSymbol.AddOption(Common.StripOuterQuotes(optionContext.STRING().GetText()), 
                    Common.StripOuterQuotes(optionContext.titleArg().STRING().GetText()));
            }

            scopeTable.AddSymbol(optionInputSymbol);
            return base.VisitOptionBox(context);
        }


        private string GetOptionBoxTitle(QikTemplateParser.OptionBoxContext context)
        {
            string titleText = null;
            if (context.optionBoxArgs().titleArg() != null)
            {
                titleText = Common.StripOuterQuotes(context.optionBoxArgs().titleArg().STRING().GetText());
            }
            return titleText;
        }

        private string GetTextBoxTitle(QikTemplateParser.TextBoxContext context)
        {
            string titleText = null;
            if (context.textBoxArgs().titleArg() != null)
            {
                titleText = Common.StripOuterQuotes(context.textBoxArgs().titleArg().STRING().GetText());
            }
            return titleText;
        }

        private string GetOptionBoxDefaultId(QikTemplateParser.OptionBoxContext context)
        {
            string defaultId = null;

            if (context.optionBoxArgs().defaultArg() != null)
            {
                defaultId = context.optionBoxArgs().defaultArg().STRING().GetText();
            }
            return defaultId;
        }

        private string GetTextBoxDefaultText(QikTemplateParser.TextBoxContext context)
        {
            string defaultText = null;

            if (context.textBoxArgs().defaultArg() != null)
            {
                defaultText = Common.StripOuterQuotes(context.textBoxArgs().defaultArg().STRING().GetText());
            }

            return defaultText;
        }
    }
}
