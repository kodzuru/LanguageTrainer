using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LanguageTrainer.Entities.Models
{
    public class User2ApplicationState
    {
        [Key]
        [Column(nameof(Id)), Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [ForeignKey("ApplicationState")]
        public int ApplicationStateId { get; set; }
        public virtual ApplicationState ApplicationState { get; set; }
    }
}
