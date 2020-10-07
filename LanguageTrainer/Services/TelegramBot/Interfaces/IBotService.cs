using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace LanguageTrainer.Services.TelegramBot
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
        void SetWebHookAsync();
    }
}
