using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public class UnknownErrorEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public UnknownErrorEventArgs(Exception exception)
        {
            this.Message = exception.Message;
        }
    }
}
