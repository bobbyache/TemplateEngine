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
            string controlId = context.VARIABLE().GetText();

            SymbolArguments symbolArguments = new SymbolArguments();
            symbolArguments.Process(context.declArgs());

            TextInputSymbol textInputSymbol = new TextInputSymbol(controlId, symbolArguments.Title, symbolArguments.Description, symbolArguments.Default, symbolArguments.IsPlaceholder);
            scopeTable.AddSymbol(textInputSymbol);

            return base.VisitTextBox(context);
        }

        public override string VisitOptionBox(QikTemplateParser.OptionBoxContext context)
        {
            string symbol = context.VARIABLE().GetText();

            SymbolArguments symbolArguments = new SymbolArguments();
            symbolArguments.Process(context.declArgs());

            OptionInputSymbol optionInputSymbol = new OptionInputSymbol(symbol, symbolArguments.Title, symbolArguments.Description, symbolArguments.Default, symbolArguments.IsPlaceholder);

            foreach (QikTemplateParser.SingleOptionContext optionContext in context.optionsBody().singleOption())
            {
                SymbolArguments optionArgs = new SymbolArguments();
                optionArgs.Process(optionContext.declArgs());

                optionInputSymbol.AddOption(Common.StripOuterQuotes(optionContext.STRING().GetText()),
                    optionArgs.Title, optionArgs.Description);
            }

            scopeTable.AddSymbol(optionInputSymbol);
            return base.VisitOptionBox(context);
        }
    }
}
