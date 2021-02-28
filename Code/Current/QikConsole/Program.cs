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
            IAppHost appHost = null;

            // Create a root command with some options
            var rootCommand = new RootCommand
            {
                // new Option<bool>("--test", "Some description")
                new Option("--get-inputs", "Do not process. Just provide input information"),
                new Option<string>(
                    "--script-file",
                    "Qik Script that will be interpreted"
                ),
                new Option<string>(
                    "--blueprints-folder",
                    "Folder in which files will be processed"
                ),
                new Option<string>(
                    "--inputs",
                    "Description"
                )
            };

            rootCommand.Description = "Qik Console Application";

            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler.Create<bool, string, string, string>((Action<bool, string, string, string>)((getInputs, scriptFile, blueprintsFolder, inputs) =>
            {
                Console.WriteLine(getInputs);
                Console.WriteLine(scriptFile);
                Console.WriteLine(blueprintsFolder);

                if (getInputs)
                {
                    Console.WriteLine(appHost.ReadInputManfest(scriptFile));
                    Console.Read();
                }
                else
                {
                    //TODO: Do a generate based on blueprint folder and script file...
                    // Consider just adding a single folder and have the Api generate based on ".qik" and other ".blu" file types.
                    throw new NotImplementedException();
                }
            }));

            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var author = config.GetSection("author").Get<Person>();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAppHost, AppHost>()
                .AddSingleton<IInputManifestHandler, InputManifestHandler>()
            .BuildServiceProvider();

            appHost = serviceProvider.GetService<IAppHost>();

            // Parse the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args).Result;
        }
}