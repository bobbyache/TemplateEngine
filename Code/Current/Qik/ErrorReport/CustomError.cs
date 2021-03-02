namespace CygSoft.Qik
{
    public class CustomError
    {
        public string Message { get; }
        public int Line { get; }
        public int Column { get; }
        public string Context { get; }

        public CustomError(int line, int column, string message, string context)
        {
            Line = line;
            Column = column;
            Message = message;
            Context = context;
        }
    }
}
