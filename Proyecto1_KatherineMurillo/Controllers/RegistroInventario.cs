using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroInventario : Controller
    {
        public static IList<Inventario> listaInventario = new List<Inventario>();
        // GET: RegistroInventario
        public ActionResult Index(string buscarIdInventario)
        {
            if (!string.IsNullOrEmpty(buscarIdInventario))
            {
                var inventarioFiltrado = listaInventario
                    .Where(e => e.IdInventario.ToString() == buscarIdInventario)
                    .ToList();
                return View(inventarioFiltrado);
            }
            return View(listaInventario);
        }

        // GET: RegistroInventario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroInventario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventario inventarioNuevo)
        {
            try
            {
                if (inventarioNuevo == null)
                {
                    return View();
                }
                else
                {
                    listaInventario.Add(inventarioNuevo);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroInventario/Edit/5
        public ActionResult Edit(int id)
        {
            if (listaInventario.Any())
            {
                Inventario inventarioEditar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == id);
                return View(inventarioEditar);
            }
            return View();
        }

        // POST: RegistroInventario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inventario inventarioEditado)
        {
            try
            {
                if (listaInventario.Any())
                {
                    Inventario inventarioEditar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == inventarioEditado.IdInventario);
                    if (inventarioEditar != null)
                    {
                        inventarioEditar.IdInventario = inventarioEditado.IdInventario;
                        inventarioEditar.Descripcion = inventarioEditado.Descripcion;
                        inventarioEditar.TipoMaquina = inventarioEditado.TipoMaquina;
                        inventarioEditar.HorasActuales = inventarioEditado.HorasActuales;
                        inventarioEditar.HorasMaximas = inventarioEditado.HorasMaximas;
                        inventarioEditar.HorasMantenimiento = inventarioEditado.HorasMantenimiento;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroInventario/Delete/5
        public ActionResult Delete(int id)
        {
            Inventario inventarioEliminar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == id);

            if ( inventarioEliminar == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(inventarioEliminar);
        }

        // POST: RegistroInventario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Inventario inventarioEliminado)
        {
            try
            {
                Inventario inventarioEliminar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == inventarioEliminado.IdInventario);

                if (inventarioEliminar != null)
                {
                    listaInventario.Remove(inventarioEliminar);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
