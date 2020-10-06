using AutoMapper;
using LanguageTrainer.Contracts;
using LanguageTrainer.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LanguageTrainer.Services.Commands.ToDo
{
    public class StartCommand : KeyboardCommand
    {
        public IRepositoryWrapper Repository { get; }
        public IMapper Mapper { get; }

        public StartCommand(CommandInfo info, IRepositoryWrapper repository, IMapper mapper) : base(info)
        {
            this.Mapper = mapper;
            this.Repository = repository;
        }
        public override async void Execute(MessageEventArgs e, ITelegramBotClient client)
        {
            Message message = e.Message;
            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.{message.Text}" +
            $"FirstName: {message.Chat.FirstName}" +
            $"LastName: {message.Chat.LastName}" +
            $"ChatId: {message.Chat.Id}" +
            $"Date: {message.Date}" +
            $"From.FirstName: {message.From.FirstName}" +
            $"From.LastName: {message.From.LastName}" +
            $"From.Id: {message.From.Id}");
            SendReplyKeyboard(message.Chat.Id, client);


            var userDTO = Mapper.Map<Message, CreateOrUpdateUserDTO>(message);
            //if (Repository.User.CreateOrUpdateUser(userDTO))
            //{
            //    await client.SendTextMessageAsync(
            //        chatId: message.Chat.Id,
            //        text: "registration SUCCESSFULL",
            //        replyToMessageId: message.MessageId
            //    );
            //}
            //else
            //{
            //    await client.SendTextMessageAsync(
            //        chatId: message.Chat.Id,
            //         text: "User already exist, restoration successfull",
            //        replyToMessageId: message.MessageId
            //    );
            //}

        }
        async void SendReplyKeyboard(long id, ITelegramBotClient client)
        {
            var replyKeyboardMarkup = new ReplyKeyboardMarkup(
                new KeyboardButton[][]
                {
                        new KeyboardButton[] { $"com1", "com2" },
                        new KeyboardButton[] { "com3", $"com4"},
                },
                resizeKeyboard: true
            );
            await client.SendTextMessageAsync(
                chatId: id,
                text: "Шо хош рабиць?",
                replyMarkup: replyKeyboardMarkup
            );
        }
    }
}
