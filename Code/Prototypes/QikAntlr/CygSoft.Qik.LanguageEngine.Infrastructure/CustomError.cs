using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public class CustomError
    {
        public string Message { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }
        public string Context { get; private set; }

        public CustomError(int line, int column, string message, string context)
        {
            this.Line = line;
            this.Column = column;
            this.Message = message;
            this.Context = context;
        }
    }
}
