using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Text.RegularExpressions;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroClientes : Controller
    {
        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> ListadoClientes()
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();
            List<cls_Clientes> lstResultado = await Obj_CNX.ListarClientes();
            return View(lstResultado);
        }
        public IActionResult AbrirCrearClientes()
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarClientes(int _iId_Clientes)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Clientes> _lstResultado = await Obj_Gestor.ConsultarClientes(new cls_Clientes { identificacion = _iId_Clientes });
            cls_Clientes Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarClientes(int _iId_Clientes)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.EliminarClientes(new cls_Clientes { identificacion = _iId_Clientes });
            return RedirectToAction("ListadoClientes", "RegistroClientes");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertClientes(cls_Clientes P_Entidad)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.AgregarClientes(P_Entidad);
            return RedirectToAction("ListadoClientes", "RegistroClientes");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClientes(cls_Clientes P_Entidad)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.ModificarClientes(P_Entidad);
            return RedirectToAction("ListadoClientes", "RegistroClientes");
        }
        #endregion
        
        /*public static IList<cls_Clientes> listaClientes = new List<cls_Clientes>(); //Lista para almacenar los clientes

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

        public ActionResult CreateNuevo(cls_Clientes clienteNuevo)
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
                cls_Clientes clienteEditar = listaClientes.FirstOrDefault(cliente => cliente.Identificacion == id);
                return View(clienteEditar);
            }
            return View();
        }

        // POST: RegistroClientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCliente(cls_Clientes clienteEditado)
        {
            try
            {
                if (listaClientes.Any()) //Verifica si la lista contiene algún elemento
                {   //Busca el primero en la lista que coincida con lo editado
                    cls_Clientes clienteEditar = listaClientes.FirstOrDefault(cliente=> cliente.Identificacion == clienteEditado.Identificacion);
                    if (clienteEditar != null) //Si se encuentra y no es nulo)
                    {   //Actualiza los campos con los valores editados
                        clienteEditar.Identificacion = clienteEditado.Identificacion;
                        clienteEditar.NombreCompleto= clienteEditado.NombreCompleto;
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
            cls_Clientes clienteEliminar = listaClientes.FirstOrDefault(cliente => cliente.Identificacion == id);
            if (clienteEliminar == null) //Verifica si no es nulo 
            {
                return RedirectToAction(nameof(Index));
            }

            return View(clienteEliminar);
        }

        // POST: RegistroClientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCliente(cls_Clientes clienteEliminado)
        {
            try
            {   //Busca el primero en la lista que coincida con lo que se va a eliminar
                cls_Clientes clienteEliminar = listaClientes.FirstOrDefault(cliente => cliente.Identificacion == clienteEliminado.Identificacion);
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
        }*/
    }
}
