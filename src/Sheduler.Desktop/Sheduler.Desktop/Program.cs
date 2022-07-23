using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Desktop.Commands;
using Sheduler.Desktop.Infrastructure.Startup;

namespace Sheduler.Desktop
{
    /// <summary>
    /// Entry point class.
    /// </summary>
    [Command(Name = "redman")]
    [Subcommand(typeof(Seed))]
    [Subcommand(typeof(CreateUser))]
    internal sealed class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Application arguments.</param>
        /// <returns>Status result.</returns>
        [STAThread]
        public static int Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                return HandleCommandLineArgumentsAsync(args).GetAwaiter().GetResult();
            }

            var app = new App();
            app.InitializeComponent();
            return app.Run();
        }

        private static async Task<int> HandleCommandLineArgumentsAsync(string[] args)
        {
            Infrastructure.DependencyInjection.LoggingModule.IsConsole = true;
            var compositionRoot = CompositionRoot.GetInstance();
            using var scope = compositionRoot.ServiceProvider.CreateScope();
            var databaseInitializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
            await databaseInitializer.InitializeAsync();

            var commandLineApplication = new CommandLineApplication<Program>();
            commandLineApplication
                .Conventions
                .UseConstructorInjection(scope.ServiceProvider)
                .UseDefaultConventions();
            return await commandLineApplication.ExecuteAsync(args);
        }

        /// <summary>
        /// Command line application execution callback.
        /// </summary>
        /// <returns>Exit code.</returns>
        public Task<int> OnExecuteAsync()
        {
            return Task.FromResult(0);
        }
    }
}
