using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private BookContext context { get; set; }

        public HomeController(BookContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var books = context.Books;
            return View(books);
        }

        public IActionResult MyBooks()
        {
            return View();
        }
    }
}
