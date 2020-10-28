using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LanguageTrainer.Entities.Models
{
    public class ApplicationState
    {
        [Key]
        [Column(nameof(Id)), Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
