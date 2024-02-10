using Microsoft.AspNetCore.Mvc;

namespace VSComMariaDB.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
