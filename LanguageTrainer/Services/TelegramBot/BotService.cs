using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LanguageTrainer.Services.TelegramBot
{
    public class BotService : IBotService
    {
        public TelegramBotClient Client { get; }

        public BotService()
        {
            Client = new TelegramBotClient(BotSettings.ApiKey);
        }
        public void SetWebHookAsync()
        {
            var client = new TelegramBotClient(BotSettings.ApiKey);
            client.SetWebhookAsync(string.Format(BotSettings.Url, "api/update")).Wait();
        }

    }
}
