using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LanguageTrainer.Entities.Models
{
    public class User
    {
        [Key]
        [Column(nameof(Id)), Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "TelegramChatId is required")]
        public long TelegramChatId { get; set; }

        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "TelegramUserId is required")]
        public int TelegramUserId { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime StartDateTime { get; set; }
        public virtual User2ApplicationState User2ApplicationState { get; set; }
    }
}
