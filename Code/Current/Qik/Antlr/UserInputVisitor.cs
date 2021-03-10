
namespace CygSoft.Qik.Antlr
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
            var controlId = context.VARIABLE().GetText();

            var symbolArguments = new SymbolArguments(errorReport);
            symbolArguments.Process(context.declArgs());

            var textInputSymbol = new TextInputSymbol(controlId, symbolArguments.Title, symbolArguments.Description, symbolArguments.Default, symbolArguments.IsPlaceholder);
            scopeTable.AddSymbol(textInputSymbol);

            return base.VisitTextBox(context);
        }

        public override string VisitOptionBox(QikTemplateParser.OptionBoxContext context)
        {
            var symbol = context.VARIABLE().GetText();

            var symbolArguments = new SymbolArguments(errorReport);
            symbolArguments.Process(context.declArgs());

            var optionInputSymbol = new OptionInputSymbol(symbol, symbolArguments.Title, symbolArguments.Description, symbolArguments.Default, symbolArguments.IsPlaceholder);

            foreach (var optionContext in context.optionsBody().singleOption())
            {
                var optionArgs = new SymbolArguments(errorReport);
                optionArgs.Process(optionContext.declArgs());

                optionInputSymbol.AddOption(Common.StripOuterQuotes(optionContext.STRING().GetText()),
                    optionArgs.Title, optionArgs.Description);
            }

            scopeTable.AddSymbol(optionInputSymbol);
            
            return base.VisitOptionBox(context);
        }
    }
}
