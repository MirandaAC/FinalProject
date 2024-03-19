using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;


namespace FinalProject.Controllers
{
    public class BookController : Controller
    {
        private BookContext context { get; set; }

        public BookController(BookContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var books = context.Books.ToList(); // Or fetch data as needed
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Book());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.BookId == 0)
                    context.Books.Add(book);
                else
                    context.Books.Update(book);

                context.SaveChanges();

                TempData["SuccessMessage"] = "Book Saved successfully";

                return RedirectToAction("Index", "Books");
            }
            else
            {
                ViewBag.Action = (book.BookId == 0) ? "Add" : "Edit";
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Book book)
        {
            var books = context.Books.Find(book.BookId);

            if (book == null)
            {
                // Product not found
                return RedirectToAction("Index", "Books");
            }

            context.Books.Remove(books);
            context.SaveChanges();

            TempData["SuccessMessage"] = "Book deleted successfully";

            return RedirectToAction("Index", "Books");
        }
    }
}
