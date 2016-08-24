using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface ICompiler
    {
        event EventHandler<CompileErrorEventArgs> CompileError;

        event EventHandler BeforeCompile;
        event EventHandler AfterCompile;

        event EventHandler BeforeInput;
        event EventHandler AfterInput;

        bool HasErrors { get; }
        string[] Placeholders { get; }
        string[] Symbols { get; }
        IExpression[] Expressions { get; }
        IInputField[] InputFields { get; }

        void Compile(string scriptText);
        void Input(string symbol, string value);

        string GetTitleOfPlaceholder(string placeholder);
        string GetValueOfPlaceholder(string placeholder);
        string GetValueOfSymbol(string symbol);
    }
}
