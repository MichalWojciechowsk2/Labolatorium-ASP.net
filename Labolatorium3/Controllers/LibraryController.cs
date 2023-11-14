using Labolatorium3.Models;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using System.Diagnostics;
using System.Reflection;

namespace Labolatorium3.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookService _bookService;
        public LibraryController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View(_bookService.FindAll());
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book model)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookService.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                _bookService.Edit(model);
                return RedirectToAction(nameof(Index));

            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _bookService.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _bookService.Delete(model.Id);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = _bookService.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Details(Book model)
        {
            return RedirectToAction("Index");
        }
    }
}
