using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroClientes : Controller
    {
        public static IList<Clientes> listaClientes = new List<Clientes>();
        // GET: RegistroClientes
        public ActionResult Index(string buscarIdentificacion)
        {
            if (!string.IsNullOrEmpty(buscarIdentificacion))
            {
                var clientesFiltrados = listaClientes
                    .Where(e => e.Identificacion.ToString() == buscarIdentificacion)
                    .ToList();
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
        public ActionResult Create(Clientes clienteNuevo)
        {
            try
            {
                if (clienteNuevo == null)
                {
                    return View();
                }
                else
                {
                    listaClientes.Add(clienteNuevo);
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
            if (listaClientes.Any())
            {
                Clientes clienteEditar = listaClientes.FirstOrDefault(cliente => cliente.Identificacion == id);
                return View(clienteEditar);
            }
            return View();
        }

        // POST: RegistroClientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clientes clienteEditado)
        {
            try
            {
                if (listaClientes.Any())
                {
                    Clientes clienteEditar = listaClientes.FirstOrDefault(cliente=> cliente.Identificacion == clienteEditado.Identificacion);
                    if (clienteEditar != null)
                    {
                        clienteEditar.Identificacion = clienteEditado.Identificacion;
                        clienteEditar.NombreCompleto = clienteEditado.NombreCompleto;
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
        {
            Clientes clienteEliminar = listaClientes.FirstOrDefault(cliente => cliente.Identificacion == id);

            if (clienteEliminar == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(clienteEliminar);
        }

        // POST: RegistroClientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Clientes clienteEliminado)
        {
            try
            {
                Clientes clienteEliminar = listaClientes.FirstOrDefault(cliente => cliente.Identificacion == clienteEliminado.Identificacion);

                if (clienteEliminar != null)
                {
                    listaClientes.Remove(clienteEliminar);
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
