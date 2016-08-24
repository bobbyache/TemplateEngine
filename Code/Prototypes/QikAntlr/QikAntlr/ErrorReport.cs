using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine
{
    internal class ErrorReport : IErrorReport
    {
        public event EventHandler<ExecutionErrorEventArgs> ExecutionErrorDetected;

        List<CustomError> errors = new List<CustomError>();

        public bool HasErrors { get { return this.errors.Count() > 0; } }
        public bool Reporting { get; set; }
        
        public CustomError[] Errors
        {
            get { return errors.ToArray(); }
        }

        public void AddError(CustomError error)
        {
            if (!this.Reporting)
                return;

            errors.Add(error);
            if (ExecutionErrorDetected != null)
                ExecutionErrorDetected(this, new ExecutionErrorEventArgs("Execution Error", error.Line, error.Column, "", error.Message));
        }

        public void Clear()
        {
            errors.Clear();
        }

        
    }
}
