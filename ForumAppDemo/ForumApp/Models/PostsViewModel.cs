using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models
{
    public class PostsViewModel
    {
        public int Id { get; init; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
