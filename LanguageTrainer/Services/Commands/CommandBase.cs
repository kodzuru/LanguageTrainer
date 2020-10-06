using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public bool Contains(string command)
        {
            return command.Contains(this.Info.Name);
        }

    }
}
