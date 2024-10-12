using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Drawing;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroMantenimiento : Controller
    {
        public static IList<Mantenimiento> listaMantenimiento = new List<Mantenimiento>(); //Lista para almacenar los mantenimientos
        // GET: RegistroMantenimiento
        public ActionResult Index(string buscarMantenimiento)
        {
            if (!string.IsNullOrEmpty(buscarMantenimiento)) //Verifica si no es nulo ni vacío
            {   //Filtra la lista de empleados buscando coincidencias con el valor del ID del mantenimiento
                var mantenimientoFiltrado = listaMantenimiento
                    .Where(e => e.IdMantenimiento.ToString() == buscarMantenimiento) //Convierte a string y se compara con la búsqueda
                    .ToList(); //Convierte el resultado filtrado en una lista
                return View(mantenimientoFiltrado);  
            }
            return View(listaMantenimiento);
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
                if (obj_mantenimiento == null) //Verifica si no es nulo 
                {
                    return View();
                }
                else
                {
                    listaMantenimiento.Add(obj_mantenimiento); //Si no es nulo se agrega a la lista
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
            if (listaMantenimiento.Any()) //Verifica si la lista contiene algún elemento
            {   //Busca el primero en la lista que coincida con el ID dado
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
                if (listaMantenimiento.Any()) //Verifica si la lista contiene algún elemento
                {   //Busca el primero en la lista que coincida con lo editado
                    Mantenimiento mantenimientoedit = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == obj_mantenimientoedit.IdMantenimiento);
                    if (mantenimientoedit != null) //Si se encuentra y no es nulo)
                    {   //Actualiza los campos con los valores editados
                        mantenimientoedit.IdMantenimiento = obj_mantenimientoedit.IdMantenimiento;
                        mantenimientoedit.IdCliente = obj_mantenimientoedit.IdCliente;
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
        {   //Busca el primero en la lista que coincida con el ID dado
            Mantenimiento obj_mantenimiento = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == id);

            if (obj_mantenimiento == null) //Verifica si no es nulo 
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
            {   //Busca el primero en la lista que coincida con lo que se va a eliminar
                Mantenimiento obj_mantenimientodelete = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == obj_mantenimiento.IdMantenimiento);
                if (obj_mantenimientodelete != null) //Verifica si no es nulo 
                {
                    listaMantenimiento.Remove(obj_mantenimientodelete); //Si se encontró lo elimina de la lista 
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
