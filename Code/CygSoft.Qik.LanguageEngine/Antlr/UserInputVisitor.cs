using CygSoft.Qik.LanguageEngine.Symbols;
using CygSoft.Qik.LanguageEngine.Antlr;
using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Antlr
{
    internal class UserInputVisitor : QikTemplateBaseVisitor<string>
    {
        private readonly IGlobalTable scopeTable;
        private readonly IErrorReport errorReport;

        internal UserInputVisitor(IGlobalTable scopeTable, IErrorReport errorReport)
        {
            this.scopeTable = scopeTable;
            this.errorReport = errorReport;
        }

        public override string VisitTextBox(QikTemplateParser.TextBoxContext context)
        {
            string controlId = context.VARIABLE().GetText();

            SymbolArguments symbolArguments = new SymbolArguments(errorReport);
            symbolArguments.Process(context.declArgs());

            TextInputSymbol textInputSymbol = new TextInputSymbol(controlId, symbolArguments.Title, symbolArguments.Description, symbolArguments.Default, symbolArguments.IsPlaceholder);
            scopeTable.AddSymbol(textInputSymbol);

            return base.VisitTextBox(context);
        }

        public override string VisitOptionBox(QikTemplateParser.OptionBoxContext context)
        {
            string symbol = context.VARIABLE().GetText();

            SymbolArguments symbolArguments = new SymbolArguments(errorReport);
            symbolArguments.Process(context.declArgs());

            OptionInputSymbol optionInputSymbol = new OptionInputSymbol(symbol, symbolArguments.Title, symbolArguments.Description, symbolArguments.Default, symbolArguments.IsPlaceholder);

            foreach (QikTemplateParser.SingleOptionContext optionContext in context.optionsBody().singleOption())
            {
                SymbolArguments optionArgs = new SymbolArguments(errorReport);
                optionArgs.Process(optionContext.declArgs());

                optionInputSymbol.AddOption(Common.StripOuterQuotes(optionContext.STRING().GetText()),
                    optionArgs.Title, optionArgs.Description);
            }

            scopeTable.AddSymbol(optionInputSymbol);
            return base.VisitOptionBox(context);
        }
    }
}
