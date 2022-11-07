using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFS.Models.DTOs
{
    public class ToDoUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime Expires { get; set; }
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; } = Status.ToDo;
    }
}
