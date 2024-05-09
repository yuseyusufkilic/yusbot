using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yusbot.Commands.Conversations
{
    public sealed class GreetingCommand: BaseCommandModule
    {
        [Command("selam"), DSharpPlus.CommandsNext.Attributes.Description("Pings the bot and returns the gateway latency."), Aliases("slm")]
        [SuppressMessage("Style", "IDE0022", Justification = "Paragraph.")]
        public async Task GreetingAsync(CommandContext context)
        {
            await context.RespondAsync($"Selam kardeşim {context.Message.Author.Username}, Yuşe'nin selamı var.");
        }
    }
}
