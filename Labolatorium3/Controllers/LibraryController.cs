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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model) 
        {
            if (ModelState.IsValid)
            {
                model.Id = id++;
                _book[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id )
        {
            return View(_book[id]);
        }
    }
}
