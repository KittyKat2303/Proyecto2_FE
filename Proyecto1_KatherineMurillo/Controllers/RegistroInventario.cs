using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Text.RegularExpressions;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroInventario : Controller
    {
        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> ListadoInventario()
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();
            List<cls_Inventario> lstResultado = await Obj_CNX.ListarInventario();
            return View(lstResultado);
        }
        public IActionResult AbrirCrearInventario()
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarInventario(int _iId_Inventario)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Inventario> _lstResultado = await Obj_Gestor.ConsultarInventario(new cls_Inventario { idInventario = _iId_Inventario });
            cls_Inventario Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarInventario(int _iId_Inventario)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.EliminarInventario(new cls_Inventario { idInventario = _iId_Inventario });
            return RedirectToAction("ListadoInventario", "RegistroInventario");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertInventario(cls_Inventario P_Entidad)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.AgregarInventario(P_Entidad);
            return RedirectToAction("ListadoInventario", "RegistroInventario");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventario(cls_Inventario P_Entidad)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.ModificarInventario(P_Entidad);
            return RedirectToAction("ListadoInventario", "RegistroInventario");
        }
        #endregion
        
        /*public static IList<cls_Inventario> listaInventario = new List<cls_Inventario>(); //Lista para almacenar los inventarios
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
        public ActionResult Create(cls_Inventario inventarioNuevo)
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
                cls_Inventario inventarioEditar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == id);
                return View(inventarioEditar);
            }
            return View();
        }

        // POST: RegistroInventario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cls_Inventario inventarioEditado)
        {
            try
            {
                if (listaInventario.Any()) //Verifica si la lista contiene algún elemento
                {   //Busca el primero en la lista que coincida con lo editado
                    cls_Inventario inventarioEditar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == inventarioEditado.IdInventario);
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
            cls_Inventario inventarioEliminar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == id);

            if (inventarioEliminar == null) //Verifica si no es nulo 
            {
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioEliminar);
        }

        // POST: RegistroInventario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(cls_Inventario inventarioEliminado)
        {
            try
            {   //Busca el primero en la lista que coincida con lo que se va a eliminar
                cls_Inventario inventarioEliminar = listaInventario.FirstOrDefault(inventario => inventario.IdInventario == inventarioEliminado.IdInventario);
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
        }*/
    }
}
