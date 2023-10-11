using Labolatorium.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Labolatorium.Controllers
{
    public enum Operators
    {
        ADD, SUB, MUL, DIV
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About(string author, int? id)
        {
            //string author = Request.Query["author"];
            ViewBag.Author = author +" "+id;
            return View();
        }
        public IActionResult Cal(string wyn, int? a, int? b)
        {
            if (wyn == "add")
            {
                ViewBag.Cal = "Wynik dodawania: " + a +" + "+ b + " = " + (a+b);
                return View();
            }
            if (wyn == "sub")
            {
                ViewBag.Cal = "Wynik odejmowania: " + a + " - " + b + " = " + (a - b);
                return View();
            }
            if (wyn == "mul")
            {
                ViewBag.Cal = "Wynik mnozenia: " + a + " * " + b + " = " + (a * b);
                return View();
            }
            if (wyn == "div")
            {
                ViewBag.Cal = "Wynik dzielenia: " + a + " / " + b + " = " + (a / b);
                return View();
            }
            else return View(); 
        }

        public IActionResult Calc([FromQuery(Name = "op")]Operators op, double? x, double? y )
        {
            if (op == null || x == null || y == null)
            {
                return View("Error");
            }

            string result;
            switch (op) 
            {
                case Operators.ADD:
                    result = $"{x}+{y}={x + y}";
                    ViewBag.Result = result;
                    break;
                case Operators.SUB:
                    result = $"{x}-{y}={x - y}";
                    ViewBag.Result = result;
                    break;
                case Operators.MUL:
                    result = $"{x}*{y}={x * y}";
                    ViewBag.Result = result;
                    break;
                case Operators.DIV:
                    result = $"{x}/{y}={x / y}";
                    ViewBag.Result = result;
                    break;

            }
            //ViewBag.Result = result;
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}