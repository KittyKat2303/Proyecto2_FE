using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroClientes : Controller
    {
        public static IList<Clientes> listaClientes = new List<Clientes>(); //Lista para almacenar los clientes

        // GET: RegistroClientes
        public ActionResult Index(string buscarIdentificacion)
        {
            if (!string.IsNullOrEmpty(buscarIdentificacion)) //Verifica si no es nulo ni vacío
            {   //Filtra la lista de empleados buscando coincidencias con el valor de la identificación
                var clientesFiltrados = listaClientes
                    .Where(e => e.Identificacion.ToString() == buscarIdentificacion) //Convierte a string y se compara con la búsqueda
                    .ToList(); //Convierte el resultado filtrado en una lista
                return View(clientesFiltrados);
            }
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

        public ActionResult CreateNuevo(Clientes clienteNuevo)
        {
            try
            {   
                if (clienteNuevo == null) //Verifica si no es nulo 
                {                   
                    return View();
                }
                else
                {
                    listaClientes.Add(clienteNuevo); //Si no es nulo se agrega a la lista
                }
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
            if (listaClientes.Any()) //Verifica si la lista contiene algún elemento
            {   //Busca el primero en la lista que coincida con el ID dado
                Clientes clienteEditar = listaClientes.FirstOrDefault(cliente => cliente.Identificacion == id);
                return View(clienteEditar);
            }
            return View();
        }

        // POST: RegistroClientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCliente(Clientes clienteEditado)
        {
            try
            {
                if (listaClientes.Any()) //Verifica si la lista contiene algún elemento
                {   //Busca el primero en la lista que coincida con lo editado
                    Clientes clienteEditar = listaClientes.FirstOrDefault(cliente=> cliente.Identificacion == clienteEditado.Identificacion);
                    if (clienteEditar != null) //Si se encuentra y no es nulo)
                    {   //Actualiza los campos con los valores editados
                        clienteEditar.Identificacion = clienteEditado.Identificacion;
                        clienteEditar.NombreCompletoClientes= clienteEditado.NombreCompletoClientes;
                        clienteEditar.Provincia = clienteEditado.Provincia;
                        clienteEditar.Canton = clienteEditado.Canton;
                        clienteEditar.Distrito = clienteEditado.Distrito;
                        clienteEditar.DireccionExacta = clienteEditado.DireccionExacta;
                        clienteEditar.MantenimientoInvierno = clienteEditado.MantenimientoInvierno;
                        clienteEditar.MantenimientoVerano = clienteEditado.MantenimientoVerano;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroClientes/Delete/5
        public ActionResult Delete(int id)
        {   //Busca el primero en la lista que coincida con el ID dado
            Clientes clienteEliminar = listaClientes.FirstOrDefault(cliente => cliente.Identificacion == id);
            if (clienteEliminar == null) //Verifica si no es nulo 
            {
                return RedirectToAction(nameof(Index));
            }

            return View(clienteEliminar);
        }

        // POST: RegistroClientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCliente(Clientes clienteEliminado)
        {
            try
            {   //Busca el primero en la lista que coincida con lo que se va a eliminar
                Clientes clienteEliminar = listaClientes.FirstOrDefault(cliente => cliente.Identificacion == clienteEliminado.Identificacion);
                if (clienteEliminar != null) //Verifica si no es nulo 
                {
                    listaClientes.Remove(clienteEliminar); //Si se encontró lo elimina de la lista 
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
