﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Drawing;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroMantenimiento : Controller
    {
        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> ListadoMantenimiento()
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();
            List<cls_Mantenimiento> lstResultado = await Obj_CNX.ListarMantenimiento();
            return View(lstResultado);
        }
        public IActionResult AbrirCrearMantenimiento()
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarMantenimiento(int _iId_Mantenimiento)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Mantenimiento> _lstResultado = await Obj_Gestor.ConsultarMantenimiento(new cls_Mantenimiento { idMantenimiento = _iId_Mantenimiento });
            cls_Mantenimiento Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarMantenimiento(int _iId_Mantenimiento)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.EliminarMantenimiento(new cls_Mantenimiento { idMantenimiento = _iId_Mantenimiento });
            return RedirectToAction("ListadoMantenimiento", "RegistroMantenimiento");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertMantenimiento(cls_Mantenimiento P_Entidad)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.AgregarMantenimiento(P_Entidad);
            return RedirectToAction("ListadoMantenimiento", "RegistroMantenimiento");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMantenimiento(cls_Mantenimiento P_Entidad)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.ModificarMantenimiento(P_Entidad);
            return RedirectToAction("ListadoMantenimiento", "RegistroMantenimiento");
        }
        #endregion

        /*public static IList<cls_Mantenimiento> listaMantenimiento = new List<cls_Mantenimiento>(); //Lista para almacenar los mantenimientos
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
        public ActionResult CreateMantenimiento(cls_Mantenimiento mantenimientoNuevo)
        {
            try
            {   
                if (mantenimientoNuevo == null) //Verifica si no es nulo 
                {
                    return View();
                }
                else
                {
                    //Valida que el ID del mantenimiento se convierte a int
                    int mantenimientoInt;
                    if (!int.TryParse(mantenimientoNuevo.IdMantenimiento.ToString(), out mantenimientoInt))
                    {
                        ModelState.AddModelError("IdMantenimiento", "El ID del mantenimiento deben ser solo números");
                        return View(mantenimientoNuevo);
                    }
                    //Verifica el ID del mantenimiento ya existe
                    if (MantenimientoYaExiste(mantenimientoInt))
                    {
                        ModelState.AddModelError("IdMantenimiento", "El ID del mantenimiento ya está registrado");
                        return View(mantenimientoNuevo);
                    }
                    listaMantenimiento.Add(mantenimientoNuevo); //Si no es nulo se agrega a la lista
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
                cls_Mantenimiento mantenimientoEditar = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == id);
                return View(mantenimientoEditar);
            }
            return View();
        }

        // POST: RegistroMantenimiento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMantenimiento(cls_Mantenimiento mantenimientoEditado)
        {
            try
            {
                if (listaMantenimiento.Any()) //Verifica si la lista contiene algún elemento
                {   //Busca el primero en la lista que coincida con lo editado
                    cls_Mantenimiento mantenimientoEditar = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == mantenimientoEditado.IdMantenimiento);
                    if (mantenimientoEditar != null) //Si se encuentra y no es nulo)
                    {   //Actualiza los campos con los valores editados
                        mantenimientoEditar.IdMantenimiento = mantenimientoEditado.IdMantenimiento;
                        mantenimientoEditar.IdCliente = mantenimientoEditado.IdCliente;
                        mantenimientoEditar.FechaEjecutado = mantenimientoEditado.FechaEjecutado;
                        mantenimientoEditar.FechaAgendado = mantenimientoEditado.FechaAgendado;
                        mantenimientoEditar.MetrosPropiedad = mantenimientoEditado.MetrosPropiedad;
                        mantenimientoEditar.MetrosCercaViva = mantenimientoEditado.MetrosCercaViva;
                        mantenimientoEditar.DiasSinChapia = mantenimientoEditado.DiasSinChapia;
                        mantenimientoEditar.FechaOtraChapia = mantenimientoEditado.FechaOtraChapia;
                        mantenimientoEditar.TipoZacate = mantenimientoEditado.TipoZacate;
                        mantenimientoEditar.AplicacionProducto = mantenimientoEditado.AplicacionProducto;
                        mantenimientoEditar.ProductoAplicado = mantenimientoEditado.ProductoAplicado;
                        mantenimientoEditar.CostoChapia = mantenimientoEditado.CostoChapia;
                        mantenimientoEditar.CostoAplicacionProducto = mantenimientoEditado.CostoAplicacionProducto;
                        mantenimientoEditar.EstadoMantenimiento = mantenimientoEditado.EstadoMantenimiento;
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
            cls_Mantenimiento mantenimientoEliminar = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == id);

            if (mantenimientoEliminar == null) //Verifica si no es nulo 
            {
                return RedirectToAction(nameof(Index));
            }
            return View(mantenimientoEliminar);
        }

        // POST: RegistroMantenimiento/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMantenimiento(cls_Mantenimiento mantenimientoEliminado)
        {
            try
            {   //Busca el primero en la lista que coincida con lo que se va a eliminar
                cls_Mantenimiento mantenimientoEliminar = listaMantenimiento.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == mantenimientoEliminado.IdMantenimiento);
                if (mantenimientoEliminar != null) //Verifica si no es nulo 
                {
                    listaMantenimiento.Remove(mantenimientoEliminar); //Si se encontró lo elimina de la lista 
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Verifica si el ID del mantenimiento ya existe
        private bool MantenimientoYaExiste(int mantenimiento)
        {
            //Comprobar si el ID del mantenimiento ya está en la lista de empleados
            return listaMantenimiento.Any(e => e.IdMantenimiento == mantenimiento);
        }*/
    }
}
