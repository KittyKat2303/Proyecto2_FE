using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroClientes : Controller
    {
        public IList<Clientes> listaClientes = new List<Clientes>();
        // GET: RegistroClientes
        public ActionResult Index()
        {
            return View(listaClientes);
        }

        // GET: RegistroClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroClientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNuevo(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroClientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistroClientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroClientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistroClientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
