using LanguageTrainer.Services.Commands;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LanguageTrainer.Services.TelegramBot
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ICommandWrapper commandWrapper;

        public UpdateService(IBotService botService, ICommandWrapper commandWrapper)
        {
            _botService = botService;
            this.commandWrapper = commandWrapper;
        }

        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
                return;

            var message = update.Message;

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
