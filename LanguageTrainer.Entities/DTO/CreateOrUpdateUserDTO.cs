using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LanguageTrainer.Entities.DTO
{
    public class CreateOrUpdateUserDTO
    {
        [Required(ErrorMessage = "TelegramChatId is required")]
        public long TelegramChatId { get; set; }
        [MaxLength(250)]
        public string FirstName { get; set; }
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "TelegramUserId is required")]
        public int TelegramUserId { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}
