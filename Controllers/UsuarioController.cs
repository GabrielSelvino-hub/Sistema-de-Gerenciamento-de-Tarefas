using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gerenciamento_de_Tarefas.Models;
using System.Web;

namespace Sistema_de_Gerenciamento_de_Tarefas.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void ChecarLogin()
        {
            var usuario = new UsuarioModel(_configuration);
            usuario.Nome = Request.Form.ToList()[0].Value;
            usuario.Senhha = Request.Form.ToList()[1].Value;

            if (usuario.PerformLogin())
            {
                HttpContext.Session.SetString("Autorizado", "OK");
                Response.Redirect("/Home/Index");
            }
            else
            {
                Response.Redirect("/Usuario/Index");
            }
        }
    }
}
