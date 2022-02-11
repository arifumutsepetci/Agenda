using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDataAccessLayer
{
    public partial class Events
    {
        [Key]
        public int ObjectId { get; set; }
        [MaxLength(50, ErrorMessage ="Title should not be longer than 50 characters.")]
        [Required(ErrorMessage = "Please type a title.")]
        public string Title { get; set; }
        [MaxLength(250)]
        public string? Explanation { get; set; }
        [Required(ErrorMessage = "Please type an event date.")]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int EventUrgencyId { get; set; }
        [MaxLength(500)]
        public string? Comment { get; set; }
        public bool IsDone { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
