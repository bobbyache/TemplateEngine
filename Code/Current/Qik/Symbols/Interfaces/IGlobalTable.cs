
namespace CygSoft.Qik
{
    public interface IGlobalTable
    {
        IExpression[] Expressions { get; }
        IInputField[] InputFields { get; }
        string[] Placeholders { get; }
        string[] Symbols { get; }

        void Clear();
        void Input(string inputSymbol, string value);

        void AddSymbol(ISymbol symbol);

        ISymbolInfo GetPlaceholderInfo(string placeholder);
        ISymbolInfo GetSymbolInfo(string symbol);
        ISymbolInfo[] GetSymbolInfoSet(string[] symbols);
        string GetTitleOfPlacholder(string placeholder);
        string GetValueOfPlacholder(string placeholder);
        string GetValueOfSymbol(string symbol);
    }
}