using Microsoft.AspNetCore.Mvc;
using System;

namespace YourNamespace.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateAge(Birth model)
        {
            if (model.IsValid())
            {
                int age = model.CalculateAge();
                ViewBag.Message = $"Cześć {model.Name}, masz {age} lat(a).";
            }
            else
            {
                ViewBag.Message = "Wprowadź poprawne dane.";
            }

            return View("Index");
        }
    }
}
