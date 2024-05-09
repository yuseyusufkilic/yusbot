using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace yusbot.Commands
{
    public sealed class PingCommand : BaseCommandModule
    {
        [Command("ping"), DSharpPlus.CommandsNext.Attributes.Description("Pings the bot and returns the gateway latency."), Aliases("pong")]
        [SuppressMessage("Style", "IDE0022", Justification = "Paragraph.")]
        public async Task PingAsync(CommandContext context)
        {
            await context.RespondAsync($"Pong! The gateway latency is {context.Client.Ping}ms.");
        }
    }
}
