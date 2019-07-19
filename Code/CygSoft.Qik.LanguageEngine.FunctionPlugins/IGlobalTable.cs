using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Scope
{
    public interface IGlobalTable
    {
        IExpression[] Expressions { get; }
        IInputField[] InputFields { get; }
        string[] Placeholders { get; }
        string[] Symbols { get; }

        ISymbolInfo GetPlaceholderInfo(string placeholder);
        ISymbolInfo GetSymbolInfo(string symbol);
        ISymbolInfo[] GetSymbolInfoSet(string[] symbols);
        string GetTitleOfPlacholder(string placeholder);
        string GetValueOfPlacholder(string placeholder);
        string GetValueOfSymbol(string symbol);
    }
}