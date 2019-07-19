using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IErrorReport
    {
        event EventHandler<CompileErrorEventArgs> ExecutionErrorDetected;

        bool HasErrors { get; }
        bool Reporting { get; set; }
        CustomError[] Errors { get; }
        void AddError(CustomError error);
        void Clear();
    }
}
