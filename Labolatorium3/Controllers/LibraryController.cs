using Labolatorium3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using ModelsLibrary;
using System.Diagnostics;
using System.Reflection;

namespace Labolatorium3.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class LibraryController : Controller
    {
        private readonly IBookService _bookService;
        public LibraryController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_bookService.FindAll());
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            Book model = new Book();
            model.Organizations = _bookService
                .FindAllOrganizationsForVieModel()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
            return View(model);
        }

            [HttpPost]
        public IActionResult AddBook(Book model)
        {
            if (ModelState.IsValid)
            {
                _bookService.FindAllOrganizationsForVieModel().Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
            .ToList();

                _bookService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult CreateApi()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateApi(Book c)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(c);
                return RedirectToAction(nameof(Index));
            }
            return View();
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
