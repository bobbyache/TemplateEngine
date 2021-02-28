
namespace CygSoft.Qik.Console
{
    public class AppHost : IAppHost
    {
        private readonly IServiceA serviceA;

        public AppHost(IServiceA mailService)
        {
            serviceA = mailService;
        }

        public void Run()
        {
            serviceA.Log("hello world!");
        }
    }
}
