using Labolatorium2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium2.Controllers
{
    public class CalculatorController : Controller
    {
        public enum Operators
        {
            ADD,
            SUB,
            MUL,
            DIV
        }
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Result([FromQuery(Name = "op")] Operators op, double? x, double? y)
        //{


        //    if (op == null || x == null || y == null)
        //    {
        //        return View("Error");
        //    }

        //    double? result = 0;
        //    string symbol = " ";

        //    switch (op)
        //    {
        //        case Operators.ADD:
        //            result = x + y;
        //            symbol = "+";

        //            break;
        //        case Operators.SUB:
        //            result = x - y;
        //            symbol = "-";

        //            break;


        //        case Operators.MUL:
        //            result = x * y;
        //            symbol = "*";

        //            break;
        //        case Operators.DIV:
        //            result = x / y;
        //            symbol = "/";

        //            break;

        //    }
        //    ViewBag.Result = result;
        //    return View();

        //}

        public IActionResult Result(Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }

        public IActionResult Form()
        {
            return View();
        }
    }
}
