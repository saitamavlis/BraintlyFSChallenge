using System.ComponentModel.DataAnnotations;

namespace ChallengeFS.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = "No Description";
        public DateTime Created { get; init; } = DateTime.Now;
        public DateTime Expires { get; set; }
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; } = Status.ToDo;
        
    }
    public enum Status
    {
        ToDo=0,
        InProgress=1,
        Done=2,
        Expired=3,
    }
}