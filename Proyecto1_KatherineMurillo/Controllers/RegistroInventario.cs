using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroInventario : Controller
    {
        public static IList<Inventario> listaInventario = new List<Inventario>(); //Lista para almacenar los inventarios
        // GET: RegistroInventario
        public ActionResult Index(string buscarIdInventario)
        {
            if (!string.IsNullOrEmpty(buscarIdInventario)) //Verifica si no es nulo ni vacío
            {   //Filtra la lista de empleados buscando coincidencias con el valor del ID del inventario
                var inventarioFiltrado = listaInventario
                    .Where(e => e.IdInventario.ToString() == buscarIdInventario) //Convierte a string y se compara con la búsqueda
                    .ToList(); //Convierte el resultado filtrado en una lista
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
                if (inventarioNuevo == null) //Verifica si no es nulo 
                {
                    return View();
                }
                else
                {
                    //Valida que el ID del inventario se convierte a int
                    int inventarioInt;
                    if (!int.TryParse(inventarioNuevo.IdInventario.ToString(), out inventarioInt))
                    {
                        ModelState.AddModelError("IdInventario", "El ID del inventario deben ser solo números");
                        return View(inventarioNuevo);
                    }
                    //Verifica si el ID del inventario ya existe
                    if (InventarioYaExiste(inventarioInt))
                    {
                        ModelState.AddModelError("IdInventario", "El ID del inventario ya está registrado");
                        return View(inventarioNuevo);
                    }
                    listaInventario.Add(inventarioNuevo); //Si no es nulo se agrega a la lista
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
            if (listaInventario.Any()) //Verifica si la lista contiene algún elemento
            {   //Busca el primero en la lista que coincida con el ID dado
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
                if (listaInventario.Any()) //Verifica si la lista contiene algún elemento
                {   //Busca el primero en la lista que coincida con lo editado
                    Inventario inventarioEditar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == inventarioEditado.IdInventario);
                    if (inventarioEditar != null) //Si se encuentra y no es nulo)
                    {   //Actualiza los campos con los valores editados
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
        {   //Busca el primero en la lista que coincida con el ID dado
            Inventario inventarioEliminar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == id);

            if (inventarioEliminar == null) //Verifica si no es nulo 
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
            {   //Busca el primero en la lista que coincida con lo que se va a eliminar
                Inventario inventarioEliminar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == inventarioEliminado.IdInventario);
                if (inventarioEliminar != null) //Verifica si no es nulo 
                {
                    listaInventario.Remove(inventarioEliminar); //Si se encontró lo elimina de la lista 
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Verifica si el ID del inventario ya existe
        private bool InventarioYaExiste(int inventario)
        {
            //Comprobar si el ID del inventario ya está en la lista de empleados
            return listaInventario.Any(e => e.IdInventario == inventario);
        }
    }
}
