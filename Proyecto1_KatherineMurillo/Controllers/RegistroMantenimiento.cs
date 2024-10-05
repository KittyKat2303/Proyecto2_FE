using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroMantenimiento : Controller
    {
        public static IList<Mantenimiento> listaMantenimiento = new List<Mantenimiento>();
        // GET: RegistroMantenimiento
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistroMantenimiento/Create
        public ActionResult AbrirCreateMatenimiento()
        {
            return View();
        }

        // POST: RegistroMantenimiento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMantenimiento(Mantenimiento obj_mantenimiento)
        {
            try
            {
                if (obj_mantenimiento == null)
                {
                    return View();
                }
                else
                {
                    listaMantenimiento.Add(obj_mantenimiento);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroMantenimiento/Edit/5
        public ActionResult AbrirEditMantenimiento(int id)
        {
            if (listaMantenimiento.Any())
            {
                Mantenimiento mantenimientoedit = listaMantenimiento.FirstOrDefault(mantenimientoedit => mantenimientoedit.IdMantenimiento == id);
                return View(mantenimientoedit);
            }
            return View();
        }

        // POST: RegistroMantenimiento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMantenimiento(Mantenimiento obj_mantenimientoedit)
        {
            try
            {
                if (listaMantenimiento.Any())
                {
                    Mantenimiento mantenimientoedit = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == obj_mantenimientoedit.IdMantenimiento);
                    if (mantenimientoedit != null)
                    {
                        mantenimientoedit.IdMantenimiento = obj_mantenimientoedit.IdMantenimiento;
                        mantenimientoedit.id_Cliente = obj_mantenimientoedit.id_Cliente;
                        mantenimientoedit.FechaEjecutado = obj_mantenimientoedit.FechaEjecutado;
                        mantenimientoedit.FechaAgendado = obj_mantenimientoedit.FechaAgendado;
                        mantenimientoedit.MetrosPropiedad = obj_mantenimientoedit.MetrosPropiedad;
                        mantenimientoedit.MetrosCercaViva = obj_mantenimientoedit.MetrosCercaViva;
                        mantenimientoedit.DiasSinChapia = obj_mantenimientoedit.DiasSinChapia;
                        mantenimientoedit.FechaOtraChapia = obj_mantenimientoedit.FechaOtraChapia;
                        mantenimientoedit.TipoZacate = obj_mantenimientoedit.TipoZacate;
                        mantenimientoedit.AplicacionProducto = obj_mantenimientoedit.AplicacionProducto;
                        mantenimientoedit.ProductoAplicado = obj_mantenimientoedit.ProductoAplicado;
                        mantenimientoedit.CostoChapia = obj_mantenimientoedit.CostoChapia;
                        mantenimientoedit.CostoAplicacionProducto = obj_mantenimientoedit.CostoAplicacionProducto;
                        mantenimientoedit.EstadoMantenimiento = obj_mantenimientoedit.EstadoMantenimiento;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroMantenimiento/Delete/5
        public ActionResult AbrirDeleteMantenimiento(int id)
        {
            Mantenimiento obj_mantenimiento = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == id);

            if (obj_mantenimiento == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(obj_mantenimiento);
        }

        // POST: RegistroMantenimiento/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMantenimiento(Mantenimiento obj_mantenimiento)
        {
            try
            {
                Mantenimiento obj_mantenimientodelete = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == obj_mantenimiento.IdMantenimiento);

                if (obj_mantenimientodelete != null)
                {
                    listaMantenimiento.Remove(obj_mantenimientodelete);
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
