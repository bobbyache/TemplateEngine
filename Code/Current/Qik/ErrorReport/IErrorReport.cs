using System;

namespace CygSoft.Qik
{
    public interface IErrorReport
    {
        event EventHandler<InterpretErrorEventArgs> ExecutionErrorDetected;

        bool HasErrors { get; }
        bool Reporting { get; set; }
        CustomError[] Errors { get; }
        void AddError(CustomError error);
        void Clear();
    }
}
