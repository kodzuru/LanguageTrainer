using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace LanguageTrainer.Services.TelegramBot
{
    public class TelegramBotService : ITelegramBotService
    {
        ITelegramBotClient botClient;

        public void Start()
        {
            botClient = new TelegramBotClient($"{BotSettings.ApiKey}");
            // await botClient.SetWebhookAsync($"{BotSettings.ApiUrl}/api/v1/update");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
            botClient.OnMessage += OnMessageReceived;
            botClient.OnCallbackQuery += BotOnCallbackQueryReceived;

            botClient.StartReceiving(Array.Empty<UpdateType>());
        }

        void OnMessageReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message.Text);
            if (!string.IsNullOrEmpty(e.Message.Text) && !string.IsNullOrWhiteSpace(e.Message.Text))
            {
                foreach (var command in Commands.KeyboardCommands)
                {
                    if (command.Contains(e.Message.Text))
                    {
                        command.Execute(e, botClient);
                        break;
                    }
                }
            }
        }
        private void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;
            Console.WriteLine(callbackQuery.Data);
            if (!string.IsNullOrEmpty(callbackQuery.Data) && !string.IsNullOrWhiteSpace(callbackQuery.Data))
            {
                foreach (var command in Commands.InlineCommands)
                {
                    if (command.Contains(callbackQuery.Data))
                    {
                        command.Execute(callbackQueryEventArgs, botClient);
                        break;
                    }
                }
            }
        }
    }
}
