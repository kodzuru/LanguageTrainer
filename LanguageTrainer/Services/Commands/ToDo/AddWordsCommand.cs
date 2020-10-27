using AutoMapper;
using LanguageTrainer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LanguageTrainer.Services.Commands.ToDo
{
    public class AddWordsCommand : CommandBase
    {
        public IRepositoryWrapper Repository { get; }
        public IMapper Mapper { get; }

        public AddWordsCommand(CommandInfo info, IRepositoryWrapper repository, IMapper mapper) : base(info)
        {
            this.Mapper = mapper;
            this.Repository = repository;
        }
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            //1. set program to waiting 2 getting words STATE
            //2. send notification what to do
        }
    }
}
