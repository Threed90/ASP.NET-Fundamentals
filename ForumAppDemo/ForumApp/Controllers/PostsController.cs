using ForumApp.Data;
using ForumApp.Data.Entities;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ForumAppDbContext data;
        public PostsController(ForumAppDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var posts = this.data.Posts
                .AsNoTracking()
                .Select(p => new PostsViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToList();

            return View(posts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PostCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            this.data.Posts.Add(post);

            this.data.SaveChanges();

            return RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(int id)
        {
            var post = this.data.Posts.Find(id);

            return View(new PostCreateViewModel()
            {
                Title = post?.Title ?? "",
                Content = post?.Content ?? ""
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, PostCreateViewModel model)
        {
            var post = this.data.Posts.Find(id);

            if(post != null)
            {
                post.Title = model.Title;
                post.Content = model.Content;

                this.data.SaveChanges();
            }

            return RedirectToAction(nameof(this.All));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var post = this.data.Posts.Find(id);

            this.data.Posts.Remove(post);
            this.data.SaveChanges();

            return RedirectToAction(nameof(this.All));
        }


        public IActionResult Cancel()
        {
            return RedirectToAction(nameof(this.All));
        }
    }
}
