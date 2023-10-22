using Labolatorium3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Labolatorium3.Controllers
{
    public class LibraryController : Controller
    {
        static readonly Dictionary<int, Book> _book= new Dictionary<int, Book>();
        static int id = 1;
        public IActionResult Index()
        {
            return View(_book);
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
                model.Id = id++;
                _book[model.Id] = model;
                return RedirectToAction("Index");
            }
                return View();

            //return View();

        }

        [HttpGet]
        public IActionResult Edit(int id )
        {
            return View(_book[id]);
        }
        [HttpPost]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                _book[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_book[id]);
        }
        [HttpPost]
        public IActionResult Delete(Book model)
        {
                _book.Remove(model.Id);
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_book[id]);
        }
        [HttpPost]
        public IActionResult Details(Book model)
        {
            return RedirectToAction("Index");
        }
    }
}
