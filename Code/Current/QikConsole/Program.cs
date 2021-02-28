using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using CygSoft.Qik.Console;

class Program
{
        public static int Main(string[] args)
        {

            // Create a root command with some options
            var rootCommand = new RootCommand
            {
                new Option<int>(
                    "--int-option",
                    getDefaultValue: () => 42,
                    description: "An option whose argument is parsed as an int"),
                new Option<bool>(
                    "--bool-option",
                    "An option whose argument is parsed as a bool"),
                new Option<FileInfo>(
                    "--file-option",
                    "An option whose argument is parsed as a FileInfo")
            };

            rootCommand.Description = "Boiler Plate Console App";

            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler.Create<int, bool, FileInfo>((intOption, boolOption, fileOption) =>
            {
                Console.WriteLine($"The value for --int-option is: {intOption}");
                Console.WriteLine($"The value for --bool-option is: {boolOption}");
                Console.WriteLine($"The value for --file-option is: {fileOption?.FullName ?? "null"}");
            });

            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");
            // .AddEnvironmentVariables("JRTech_");

            var config = builder.Build();
            var author = config.GetSection("author").Get<Person>();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAppHost, AppHost>()
                .AddSingleton<IServiceA, ServiceA>()
            .BuildServiceProvider();

            var appHost = serviceProvider.GetService<IAppHost>();
            appHost.Run();

            // Parse the incoming args and invoke the handler
            var result = rootCommand.InvokeAsync(args).Result;

            Console.ReadLine();
            
            return result;
        }
}