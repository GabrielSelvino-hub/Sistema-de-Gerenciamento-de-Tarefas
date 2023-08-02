using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gerenciamento_de_Tarefas.Context;
using Sistema_de_Gerenciamento_de_Tarefas.Models;
using System.Diagnostics;

namespace Sistema_de_Gerenciamento_de_Tarefas.Controllers
{
    public class HomeController : Controller
    {
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