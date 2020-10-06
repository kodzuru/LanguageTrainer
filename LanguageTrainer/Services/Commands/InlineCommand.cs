using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace LanguageTrainer.Services.Commands
{
    public class InlineCommand : CommandBase
    {
        public InlineCommand(CommandInfo info) : base(info) { }
        public virtual async void Execute(CallbackQueryEventArgs e, ITelegramBotClient client) { }
    }
}
