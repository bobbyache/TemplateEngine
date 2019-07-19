using System;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface ISyntaxValidator
    {
        event EventHandler<CompileErrorEventArgs> CompileError;
        bool HasErrors { get; }
        void Validate(string scriptText);
    }
}
