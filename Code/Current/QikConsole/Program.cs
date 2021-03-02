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
                new Option<string>("--script-file", "Qik Script that will be interpreted"),
                new Option<string>("--blueprints-folder", "Folder in which files will be processed"),
                new Option("--get-inputs", "Do not process. Just provide input information"),
                // new Option("--path", "The path (can be a qik file or a folder containining a qik file"),
                new Option<string>("--inputs", "Description"),
                new Option("--prompt")
            };

            rootCommand.Description = "Qik Console Application";

            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler.Create<bool, bool, string, string, string>((Action<bool, bool, string, string, string>)(
                (
                    getInputs, 
                    prompt, 
                    scriptFile, 
                    blueprintsFolder, 
                    inputs
                ) =>
            {
                // Console.WriteLine(scriptFile);
                // Console.WriteLine(blueprintsFolder);

                // Console.WriteLine(getInputs);
                // // Console.WriteLine(path);
                // Console.WriteLine(inputs);

                if (prompt)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Qik");
                    Console.WriteLine("Please supply a folder that contains a *.qik file or a *.qik file:");
                    var path = Console.ReadLine();
                    // Console.WriteLine($"You entered ${path}");
                    appHost.Generate(path);
                    // appHost
                }
                else if (getInputs)
                {
                    Console.WriteLine(appHost.GetJsonInputInterface(scriptFile));
                    // TODO: If a project folder is provided, find the qik file and process generate the input manifest for it.
                    //      If the file path is provided generate the input manifest from it.
                    // So a single --path should actually be enough
                    // Console.WriteLine(appHost.ReadInputManfest(path));
                    Console.Read();
                }
                else
                {
                    // TODO: If a project folder is provided, find the qik file and process all the other *.blu files.
                    //      If the file path is provided, use the qik file's folder to process all *.blu files.
                    //      Look at CodeCat to see what the file structure looks like
                    // So a single --path should actually be enough
                    throw new NotImplementedException();
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