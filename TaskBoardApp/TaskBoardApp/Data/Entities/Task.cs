namespace TaskBoardApp.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.DataConstants.Task;
    public class Task
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxTaskTitle)]
        public string Title { get; set; }

        [Required]
        [MaxLength(MaxTaskDescription)]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; init; }

        [Required]
        public string OwnerId { get; set; }
        public User Owner { get; init; }
    }
}
