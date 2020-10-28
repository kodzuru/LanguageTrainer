using AutoMapper;
using LanguageTrainer.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var state = Repository.ApplicationStateRepository.FindByCondition(x => x.Id.Equals((int)EnumsCollection.ApplicationState.INSERTING_WORDS)).FirstOrDefault();
            if(state != null)
            {
                var user = Repository.UserRepository.FindByCondition(x => x.TelegramChatId.Equals(message.Chat.Id)).FirstOrDefault();
                if(user != null)
                {
                    var user2state = Repository.User2ApplicationState.FindByCondition(x => x.UserId.Equals(user.Id)).FirstOrDefault();
                    if (user2state != null)
                    {
                        user2state.ApplicationStateId = state.Id;
                        Repository.User2ApplicationState.Update(user2state);
                        Repository.Save();
                    }
                }
            }
            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                 text: "inserting words STATE: file, link, word",
                replyToMessageId: message.MessageId
            );
        }
    }
}
