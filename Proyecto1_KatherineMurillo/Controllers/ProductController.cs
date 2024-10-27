using Microsoft.AspNetCore.Mvc;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class ProductController : Controller
    {

        #region EVENTO DE APERTURA VIEW
        public IActionResult Index()
        {
            return View();
        }

        #endregion

    }
}
