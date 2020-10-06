using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace LanguageTrainer.Services.Commands
{
    public class KeyboardCommand : CommandBase
    {
        public KeyboardCommand(CommandInfo info) : base(info) { }
        public virtual async void Execute(MessageEventArgs e, ITelegramBotClient client) { }
    }
}
