using Microsoft.AspNetCore.Mvc;

namespace Sistema_de_Gerenciamento_de_Tarefas.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
