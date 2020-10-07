using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LanguageTrainer.Services.Commands
{
    public abstract class CommandBase
    {
        public CommandInfo Info { get; set; }
        public CommandBase(CommandInfo info)
        {
            Info = new CommandInfo();
            this.Info.Name = info.Name;
            this.Info.CommandResponsibility = info.CommandResponsibility;
        }
        public virtual async Task Execute(Message message, ITelegramBotClient botClient) { }
        public bool Contains(string command)
        {
            return command.Contains(this.Info.Name);
        }

    }
}
