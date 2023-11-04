using Labolatorium3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace Labolatorium3.Controllers
{
    public class LibraryController : Controller
    {
        //static readonly Dictionary<int, Book> _book = new Dictionary<int, Book>();
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

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var bookToDelete = _bookService.FindById(id);

        //    if (bookToDelete != null)
        //    {
        //        _bookService.Delete(id);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

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





        //static readonly Dictionary<int, Book> _book= new Dictionary<int, Book>();
        //static int id = 1;
        //public IActionResult Index()
        //{
        //    return View(_book.Values.ToList());
        //}        

        //[HttpGet]
        //public IActionResult AddBook()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddBook(Book model) 
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.Id = id++;
        //        _book[model.Id] = model;
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }



        //}

        //[HttpGet]
        //public IActionResult Edit(int id )
        //{
        //    return View(_book[id]);
        //}
        //[HttpPost]
        //public IActionResult Edit(Book model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _book[model.Id] = model;
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    return View(_book[id]);
        //}
        //[HttpPost]
        //public IActionResult Delete(Book model)
        //{
        //        _book.Remove(model.Id);
        //        return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult Details(int id)
        //{
        //    return View(_book[id]);
        //}
        //[HttpPost]
        //public IActionResult Details(Book model)
        //{
        //    return RedirectToAction("Index");
        //}
    }
}
