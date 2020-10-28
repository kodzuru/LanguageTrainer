using LanguageTrainer.Contracts;
using LanguageTrainer.Services.Commands;
using LanguageTrainer.Services.Commands.ToDo;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LanguageTrainer.Services.TelegramBot
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ICommandWrapper commandWrapper;
        private IRepositoryWrapper Repository { get; }

        public UpdateService(IBotService botService, ICommandWrapper commandWrapper, IRepositoryWrapper repository)
        {
            _botService = botService;
            this.commandWrapper = commandWrapper;
            this.Repository = repository;
        }

        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
                return;

            var message = update.Message;

            Debug.WriteLine($"Received a text message in chat {message.Chat.Id}.{message.Text}" +
            $"FirstName: {message.Chat.FirstName}" +
            $"LastName: {message.Chat.LastName}" +
            $"ChatId: {message.Chat.Id}" +
            $"Date: {message.Date}" +
            $"From.FirstName: {message.From.FirstName}" +
            $"From.LastName: {message.From.LastName}" +
            $"From.Id: {message.From.Id}");

            //var state = Repository.User2ApplicationState.FindByCondition(x => x.User.TelegramChatId.Equals(message.Chat.Id)).FirstOrDefault();
            //if(state == null)
            //{
            //    commandWrapper.Commands.FirstOrDefault(x => x is StartCommand)?.Execute(message, _botService.Client);
            //    await _botService.Client.SendTextMessageAsync(
            //        chatId: message.Chat.Id,
            //        text: "YOU WAS REGISTRATED",
            //        replyToMessageId: message.MessageId
            //    );
            //}
            var userState = Repository.User2ApplicationState.FindByCondition(x => x.User.TelegramChatId.Equals(message.Chat.Id)).FirstOrDefault();
            if (userState != null && userState.ApplicationStateId.Equals((int)EnumsCollection.ApplicationState.INSERTING_WORDS))
            {
                foreach (var command in commandWrapper.Commands)
                {
                    if (command is InsertWordsCommand)
                    {
                        await command.Execute(message, _botService.Client);
                        break;
                    }
                }
                return;
            }

            switch (message.Type)
            {
                case MessageType.Text:
                    // Echo each Message
                    foreach (var command in commandWrapper.Commands)
                    {
                        if (command.Contains(message.Text))
                        {
                            await command.Execute(message, _botService.Client);
                            break;
                        }
                    }

                    //await _botService.Client.SendTextMessageAsync(message.Chat.Id, "sasai petuch");
                    break;
            }
        }
    }
}
