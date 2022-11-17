namespace TaskBoardApp.Data.DataModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using System.Runtime.CompilerServices;

    using Entities;
    using Microsoft.AspNetCore.Identity;

    public static class SeedDataConfidurationExtension
    {
        private static User GuestUser = GetUser();
        public static void SeedData(this ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasData(GuestUser);

            builder
                .Entity<Board>()
                .HasData(GetBoards());

            builder
                .Entity<Task>()
                .HasData(GetTasks());
        }

        private static User GetUser()
        {
            var guestUser = new User()
            {
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Guest",
                LastName = "User"
            };

            var hasher = new PasswordHasher<IdentityUser>();

            guestUser.PasswordHash = hasher.HashPassword(guestUser, "guest");

            return guestUser;
        }

        private static List<Board> GetBoards()
        {
            return new List<Board>()
            {
                new Board()
                {
                    Id = 1,
                    Name = "Open"
                },
                new Board()
                {
                    Id = 2,
                    Name = "In Progress"
                },
                new Board()
                {
                    Id = 3,
                    Name = "Done"
                }
            };
        }

        private static List<Task> GetTasks()
        {
            return new()
            {
                new Task()
                {
                    Id = 1,
                    Title = "Prepare for ASP.NET Fundamentals exam",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = GuestUser.Id,
                    BoardId = 1
                },
                new Task()
                {
                    Id = 2,
                    Title = "Improve EF Core skills",
                    Description = "Learn using EF Core and MS SQL Server Management Studio",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = GuestUser.Id,
                    BoardId = 3
                },
                new Task()
                {
                    Id = 3,
                    Title = "Improve ASP.NET Core skills",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddMonths(-10),
                    OwnerId = GuestUser.Id,
                    BoardId = 2
                },
                new Task()
                {
                    Id = 4,
                    Title = "Prepare for C# Fundamentals Exam",
                    Description = "Prepare by solving old Mid and Final exams",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = GuestUser.Id,
                    BoardId = 3
                }
            };
        }
    }
}
