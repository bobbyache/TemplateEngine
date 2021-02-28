
using System.Diagnostics;

namespace CygSoft.Qik.Console
{
    public class ServiceA : IServiceA
    {
        public void Log(string message)
        {
            Debug.Write(message);
        }
    }
}
