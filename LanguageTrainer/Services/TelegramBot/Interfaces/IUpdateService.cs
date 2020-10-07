using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LanguageTrainer.Services.TelegramBot
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
