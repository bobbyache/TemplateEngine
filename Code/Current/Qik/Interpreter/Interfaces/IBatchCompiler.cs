using System;

namespace CygSoft.Qik
{
    public interface IBatchCompiler
    {
        event EventHandler<CompileErrorEventArgs> CompileError;

        event EventHandler BeforeCompile;
        event EventHandler AfterCompile;

        event EventHandler BeforeInput;
        event EventHandler AfterInput;

        string[] Placeholders { get; }
        ISymbolInfo GetSymbolInfo(string symbol);
        void Compile(string scriptText);    // Compile the script text...
        string SymbolFromField(string fieldName); // TextToSymbol
        void CreateFieldInput(string symbol, string fieldName, string description); // CreateAutoInput
        void Input(string symbol, string fieldValue);
        string GetValueOfPlaceholder(string placeholder);

        ISymbolInfo[] GetSymbolInfoSet(string[] symbols);
    }
}
