using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDataAccessLayer
{
    public partial class EventUrgency
    {
        [Key]
        public int ObjectId { get; set; }
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
