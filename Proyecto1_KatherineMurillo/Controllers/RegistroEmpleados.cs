using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Text.RegularExpressions;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroEmpleados : Controller
    {
        public static IList<Empleados> listaEmpleados = new List<Empleados>(); //Lista para almacenar los empleados

        // GET: RegistroEmpleados
        public ActionResult Index(string buscarCedula)
        {           
            if (!string.IsNullOrEmpty(buscarCedula)) //Verifica si no es nulo ni vacío
            {   //Filtra la lista de empleados buscando coincidencias con el valor de la cédula            
                var empleadosFiltrados = listaEmpleados 
                    .Where(e => e.Cedula.ToString() == buscarCedula) //Convierte a string y se compara con la búsqueda
                    .ToList(); //Convierte el resultado filtrado en una lista
                return View(empleadosFiltrados);
            }            
            return View(listaEmpleados);
        }       

        // GET: RegistroEmpleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroEmpleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleados empleadoNuevo)
        {
            try
            {  
                if (empleadoNuevo == null) //Verifica si no es nulo 
                {
                    return View();
                }
                else
                {
                    //Valida que la cédula se convierte a int
                    int cedulaInt;
                    if (!int.TryParse(empleadoNuevo.Cedula.ToString(), out cedulaInt))
                    {
                        ModelState.AddModelError("Cedula", "La cédula deben ser solo números"); 
                        return View(empleadoNuevo); 
                    }
                    //Verifica si la cédula ya existe
                    if (CedulaYaExiste(cedulaInt))
                    {
                        ModelState.AddModelError("Cedula", "La cédula ya está registrada"); 
                        return View(empleadoNuevo); 
                    }                    
                    listaEmpleados.Add(empleadoNuevo); 
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroEmpleados/Edit/5
        public ActionResult Edit(int id) 
        {
            if (listaEmpleados.Any()) //Verifica si la lista contiene algún elemento
            {   //Busca el primero en la lista que coincida con el ID dado
                Empleados empleadoEditar = listaEmpleados.FirstOrDefault(empleado => empleado.Cedula == id);
                return View(empleadoEditar);
            }
            return View();
        }

        // POST: RegistroEmpleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empleados empleadoEditado)
        {
            try
            {
                if (listaEmpleados.Any()) //Verifica si la lista contiene algún elemento
                {   //Busca el primero en la lista que coincida con lo editado
                    Empleados empleadoEditar = listaEmpleados.FirstOrDefault(empleado => empleado.Cedula == empleadoEditado.Cedula);
                    if (empleadoEditar != null) //Si se encuentra y no es nulo)
                    {   //Actualiza los campos con los valores editados
                        empleadoEditar.Cedula = empleadoEditado.Cedula;
                        empleadoEditar.NombreCompletoEmpleados = empleadoEditado.NombreCompletoEmpleados;
                        empleadoEditar.FechaNacimiento = empleadoEditado.FechaNacimiento;
                        empleadoEditar.Lateralidad = empleadoEditado.Lateralidad;
                        empleadoEditar.FechaIngreso = empleadoEditado.FechaIngreso;
                        empleadoEditar.SalarioHora = empleadoEditado.SalarioHora;                        
                    }                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroEmpleados/Delete/5
        public ActionResult Delete(int id)
        {   //Busca el primero en la lista que coincida con el ID dado
            Empleados empleadoEliminar = listaEmpleados.FirstOrDefault(empleado => empleado.Cedula == id);
            if (empleadoEliminar == null) //Verifica si no es nulo 
            {
                return RedirectToAction(nameof(Index));
            }
            return View(empleadoEliminar); 
        }

        // POST: RegistroEmpleados/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Empleados empleadoEliminado)
        {
            try
            {   //Busca el primero en la lista que coincida con lo que se va a eliminar
                Empleados empleadoEliminar = listaEmpleados.FirstOrDefault(empleado => empleado.Cedula == empleadoEliminado.Cedula);
                if (empleadoEliminar != null) //Verifica si no es nulo 
                {
                    listaEmpleados.Remove(empleadoEliminar); //Si se encontró lo elimina de la lista 
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Verifica si la cédula ya existe
        private bool CedulaYaExiste(int cedula)
        {
            //Comprobar si la cédula ya está en la lista de empleados
            return listaEmpleados.Any(e => e.Cedula == cedula);
        }

        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> ListadoEmpleados()
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();
            List<Empleados> lstResultado = await Obj_CNX.ListarEmpleados();
            return View(lstResultado);
        }
        public async Task<IActionResult> FiltrarEmpleado(string _sIdBuscar) 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<Empleados> lstResultado = await Obj_CNX.ListarEmpleados();
            if (!string.IsNullOrEmpty(_sIdBuscar)) 
            {
                lstResultado = lstResultado.FindAll(item => item.iCedula.ToString().Contains(_sIdBuscar, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(lstResultado);
        }
        public IActionResult AbrirCrearEmpleado()
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarEmpleado(int _iId_Empleado)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<Empleados> _lstResultado = await Obj_Gestor.ConsultarEmpleados(new Empleados { iCedula = _iId_Empleado });
            Empleados Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            return View(Obj_Encontrado);
        }
        
        [HttpGet]
        public async Task<IActionResult> AbrirEliminarEmpleado(int _iId_Empleado)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.EliminarEmpleados(new Empleados { iCedula = _iId_Empleado });
            return RedirectToAction("ListadoEmpleados", "RegistroEmpleados");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertEmpleado(Empleados P_Entidad)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.AgregarEmpleados(P_Entidad);
            return RedirectToAction("ListadoEmpleados", "RegistroEmpleados");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmpleado(Empleados P_Entidad)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.ModificarEmpleados(P_Entidad);
            return RedirectToAction("ListadoEmpleados", "RegistroEmpleados");
        }
        #endregion
    }
}
