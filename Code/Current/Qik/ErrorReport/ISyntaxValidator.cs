using System;

namespace CygSoft.Qik
{
    public interface ISyntaxValidator
    {
        event EventHandler<CompileErrorEventArgs> CompileError;
        bool HasErrors { get; }
        void Validate(string scriptText);
    }
}
