using Microsoft.AspNetCore.Mvc;
using Spg.Fachtheorie.Aufgabe2.Mvc.Models;
using Spg.Fachtheorie.Domain.Model;
using System.Diagnostics;

namespace Spg.Fachtheorie.Aufgabe2.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}