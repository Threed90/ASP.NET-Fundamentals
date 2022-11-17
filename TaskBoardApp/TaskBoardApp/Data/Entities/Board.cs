namespace TaskBoardApp.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.DataConstants.Board;
    public class Board
    {

        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxBoardName)]
        public string Name { get; init; }

        public ICollection<Task> Tasks { get; init; }
    }
}