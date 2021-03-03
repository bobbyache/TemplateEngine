using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using CygSoft.Qik;
using CygSoft.Qik.Console;

class Program
{
        public static int Main(string[] args)
        {
            IAppHost appHost = null;

            var rootCommand = new RootCommand
            {
                new Option(new[] { "--inputs", "-i" }, "Do not process. Just provide input information"),
                new Option<string>( new[] { "--path", "-p" } , "The path (can be a qik file or a folder containining a qik file")
            };

            rootCommand.Description = "Qik Console Application";

            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler.Create<bool, string>((Action<bool, string>)(
                (
                    inputs,
                    path
                ) =>
            {
                // Console.WriteLine(inputs);
                // Console.WriteLine(path);

                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Welcome to Qik");
                    Console.WriteLine("Please specify a path. See --help for more information.");
                }

                if (inputs && !string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Welcome to Qik");
                    Console.WriteLine("Generating inputs");

                    Console.WriteLine(appHost.GetJsonInputInterface(path));
                }
                else if (!string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Welcome to Qik");
                    Console.WriteLine("Generating output files");
                    appHost.Generate(path);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please see --help for information.");
                }
            }));

            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            var config = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IJsonFunctions, JsonFunctions>()
                .AddSingleton<IFileFunctions, FileFunctions>()
                .AddSingleton<ICompiler, Compiler>()
                .AddSingleton<IAppHost, AppHost>()
            .BuildServiceProvider();

            appHost = serviceProvider.GetService<IAppHost>();

            // Parse the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args).Result;
        }
}