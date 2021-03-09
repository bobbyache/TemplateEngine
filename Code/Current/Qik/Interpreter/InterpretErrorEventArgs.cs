using System;

namespace CygSoft.Qik
{
    public class InterpretErrorEventArgs
    {
        public int Line { get; }
        public int Column { get; }
        public string Message { get; }
        public string OffendingSymbol { get; }
        public string Location { get; }

        public InterpretErrorEventArgs(string location, int line, int column, string offendingSymbol, string message)
        {
            Line = line;
            Column = column;
            Message = message;
            OffendingSymbol = offendingSymbol;
            Location = location;
        }

        public InterpretErrorEventArgs(Exception exception)
        {
            Line = 0;
            Column = 0;
            Message = exception.Message;
            OffendingSymbol = "";
            Location = "Main Template";
        }
    }
}
