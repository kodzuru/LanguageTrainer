﻿using AutoMapper;
using LanguageTrainer.Contracts;
using LanguageTrainer.Entities.DTO;
using LanguageTrainer.Services.TelegramBot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LanguageTrainer.Services.Commands.ToDo
{
    public class StartCommand : CommandBase
    {
        public IRepositoryWrapper Repository { get; }
        public IMapper Mapper { get; }

        public StartCommand(CommandInfo info, IRepositoryWrapper repository, IMapper mapper) : base(info)
        {
            this.Mapper = mapper;
            this.Repository = repository;
        }
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            Debug.WriteLine($"Received a text message in chat {message.Chat.Id}.{message.Text}" +
            $"FirstName: {message.Chat.FirstName}" +
            $"LastName: {message.Chat.LastName}" +
            $"ChatId: {message.Chat.Id}" +
            $"Date: {message.Date}" +
            $"From.FirstName: {message.From.FirstName}" +
            $"From.LastName: {message.From.LastName}" +
            $"From.Id: {message.From.Id}");
            SendReplyKeyboard(message.Chat.Id, client);


            var userDTO = Mapper.Map<Message, CreateOrUpdateUserDTO>(message);
            var user = Mapper.Map<LanguageTrainer.Entities.Models.User>(userDTO);
            var userExist = Repository.UserRepository.FindByCondition(x => x.TelegramChatId.Equals(user.TelegramChatId)).FirstOrDefault();
            if (userExist == null)
            {
                Repository.UserRepository.Create(user);
                Repository.Save();
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "registration SUCCESSFULL",
                    replyToMessageId: message.MessageId
                );
            }
            else
            {
                Mapper.Map<CreateOrUpdateUserDTO, LanguageTrainer.Entities.Models.User>(userDTO, userExist);
                Repository.UserRepository.Update(userExist);
                Repository.Save();
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                     text: "User already exist, restoration successfull",
                    replyToMessageId: message.MessageId
                );
            }
        }
        async void SendReplyKeyboard(long id, ITelegramBotClient client)
        {
            var replyKeyboardMarkup = new ReplyKeyboardMarkup(
                new KeyboardButton[][]
                {
                        new KeyboardButton[] { $"{BotSettings.KeyboardCommands.GetWords}", "com2" },
                        new KeyboardButton[] { "com3", "com4"},
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
