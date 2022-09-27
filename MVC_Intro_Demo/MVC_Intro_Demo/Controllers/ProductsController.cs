using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC_Intro_Demo.Models;
using System.Text;
using System.Text.Json;

namespace MVC_Intro_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel()
            {
                Id = 1,
                Name = "Bread",
                Price = 1.50
            },
        };

        [ActionName("My-Products")]
        public IActionResult All()
        {
            return View(this.products);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }
        public IActionResult AllAsText()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pr in this.products)
            {
                sb.AppendLine($"Product {pr.Id}: {pr.Name} - {pr.Price:F2}lv");
            }

            return Content(sb.ToString().TrimEnd());
        }
        public IActionResult AllAsTextFile()
        {
            Response.Headers.Add("Content-Disposition", "attachment;filename=products.txt");

            StringBuilder sb = new StringBuilder();

            foreach (var pr in this.products)
            {
                sb.AppendLine($"Product {pr.Id}: {pr.Name} - {pr.Price:F2}lv");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }

        public IActionResult ById(int id)
        {
            var product = this.products
                .FirstOrDefault(p => p.Id == id);

            if(product == null)
            {
                return BadRequest();
            }
            return View(product);
        }
    }
}
