using ForumApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) 
            : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Post>()
            //    .HasData(GetPosts());

            base.OnModelCreating(modelBuilder);
        }

        private Post[] GetPosts()
        {
            var data = File.ReadAllText("./DataSeed.json");

            return JsonConvert.DeserializeObject<Post[]>(data) ?? Array.Empty<Post>();
        }
    }
}
