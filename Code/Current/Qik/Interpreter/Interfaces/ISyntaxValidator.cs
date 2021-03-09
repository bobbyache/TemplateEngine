using System;

namespace CygSoft.Qik
{
    public interface ISyntaxValidator
    {
        event EventHandler<InterpretErrorEventArgs> CompileError;
        bool HasErrors { get; }
        void Validate(string scriptText);
    }
}
