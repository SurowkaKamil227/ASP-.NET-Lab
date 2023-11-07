using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3.Controllers
{
    public class BookController : Controller
    {
        private static Dictionary<int, Book> _books = new Dictionary<int, Book>();

        [HttpGet]
        public IActionResult Index()
        {
            var books = _books.Values.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                int id = _books.Keys.Count != 0 ? _books.Keys.Max() + 1 : 1;
                model.Id = id;
                _books.Add(id, model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_books.ContainsKey(id))
            {
                var book = _books[id];
                return View(book);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                if (_books.ContainsKey(model.Id))
                {
                    _books[model.Id] = model;
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_books.ContainsKey(id))
            {
                var book = _books[id];
                return View(book);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_books.ContainsKey(id))
            {
                var book = _books[id];
                return View(book);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _books.Remove(book.Id);
            return RedirectToAction("Index");
        }
    }

}
