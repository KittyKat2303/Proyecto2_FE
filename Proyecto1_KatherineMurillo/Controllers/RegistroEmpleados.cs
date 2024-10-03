using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroEmpleados : Controller
    {
        public static IList<Empleados> listaEmpleados = new List<Empleados>();
        // GET: RegistroEmpleados
        public ActionResult Index()
        {          
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
                if (empleadoNuevo == null)
                {
                    return View();
                }
                else
                {
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
            if (listaEmpleados.Any())
            {
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
                if (listaEmpleados.Any())
                {
                    Empleados empleadoEditar = listaEmpleados.FirstOrDefault(empleado => empleado.Cedula == empleadoEditado.Cedula);
                    if (empleadoEditar != null) {
                        empleadoEditar.Cedula = empleadoEditado.Cedula;
                        empleadoEditar.FechaNacimiento = empleadoEditado.FechaNacimiento;
                        empleadoEditar.Lateralidad = empleadoEditado.Lateralidad;
                        empleadoEditar.FechaIngreso = empleadoEditado.FechaIngreso;
                        empleadoEditar.SalarioHora = empleadoEditado.SalarioHora; 
                        listaEmpleados.Add(empleadoEditado);
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
        {
            Empleados empleadoEliminar = listaEmpleados.FirstOrDefault(empleado => empleado.Cedula == id);

            if (empleadoEliminar == null)
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
            {
                Empleados empleadoEliminar = listaEmpleados.FirstOrDefault(empleado => empleado.Cedula == empleadoEliminado.Cedula);

                if (empleadoEliminar != null)
                {
                    listaEmpleados.Remove(empleadoEliminar);
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
