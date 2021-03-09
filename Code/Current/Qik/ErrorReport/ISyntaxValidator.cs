using System;

namespace CygSoft.Qik
{
    // TODO: Move into Interpreter folder where it belongs.
    public interface ISyntaxValidator
    {
        event EventHandler<InterpretErrorEventArgs> CompileError;
        bool HasErrors { get; }
        void Validate(string scriptText);
    }
}
