using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace yusbot
{
    public sealed class Program
    {
        public static async Task Main(string[] args)
        {
            string? token = ConfigurationManager.AppSettings["TOKEN"];
            if (string.IsNullOrWhiteSpace(token)) {
                Console.WriteLine("Please specify a TOKEN variable in App.Config.");
                Environment.Exit(1);
                return;
            }

            DiscordConfiguration config = new()
            {
                Token = token,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            };

            DiscordClient client = new(config);
            DiscordActivity status = new("with fire", ActivityType.Playing);

            ServiceCollection serviceCollection = new();
            serviceCollection.AddSingleton(Random.Shared);

            CommandsNextConfiguration commandsConfig = new()
            {

                Services = serviceCollection.BuildServiceProvider(),
                StringPrefixes = new[] { "!" }
            };
            CommandsNextExtension commandsNext = client.UseCommandsNext(commandsConfig);

            commandsNext.RegisterCommands(typeof(Program).Assembly);

            await client.ConnectAsync(status, UserStatus.Online);

            await Task.Delay(-1);


        }
    }
}