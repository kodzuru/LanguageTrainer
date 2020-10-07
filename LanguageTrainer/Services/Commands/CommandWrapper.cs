using AutoMapper;
using LanguageTrainer.Contracts;
using LanguageTrainer.Services.Commands.ToDo;
using LanguageTrainer.Services.TelegramBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LanguageTrainer.EnumsCollection;

namespace LanguageTrainer.Services.Commands
{
    public class CommandWrapper : ICommandWrapper
    {
        public IRepositoryWrapper RepositoryWrapper { get; }
        public IMapper Mapper { get; }
        public CommandWrapper(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.Mapper = mapper;
            RepositoryWrapper = repositoryWrapper;
            RegistrateAllCommands();
        }
        public List<CommandBase> Commands { get; set; } = new List<CommandBase>();
        private void RegistrateAllCommands()
        {
            Commands.Add(new StartCommand(
                new CommandInfo()
                {
                    Name = $"{BotSettings.Start}",
                    CommandResponsibility = CommandResponsibility.Inline
                }, RepositoryWrapper, Mapper
            ));
        }
    }
}
