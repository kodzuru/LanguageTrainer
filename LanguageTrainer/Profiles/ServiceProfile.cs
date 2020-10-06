using AutoMapper;
using LanguageTrainer.Entities.DTO;

namespace LanguageTrainer.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Telegram.Bot.Types.Message, CreateOrUpdateUserDTO>()
                .ForMember("TelegramChatId", x => x.MapFrom(c => c.Chat.Id))
                .ForMember("FirstName", x => x.MapFrom(c => c.From.FirstName))
                .ForMember("LastName", x => x.MapFrom(c => c.From.LastName))
                .ForMember("TelegramUserId", x => x.MapFrom(c => c.From.Id))
                .ForMember("StartDateTime", x => x.MapFrom(c => c.Date));
        }
    }
}
