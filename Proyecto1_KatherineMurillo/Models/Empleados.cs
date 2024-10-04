using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Proyecto1_KatherineMurillo.Models
{
    public class Empleados
    {
        [Required(ErrorMessage = "La cédula es requerida")]
        //[Display(Name = "Cédula")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        //[Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La lateralidad es requerida")]
        public string Lateralidad { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es requerida")]
        //[Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }


        [Required(ErrorMessage = "El salario por hora es requerida")]
        //[Display(Name = "Salario por hora")]

        public float SalarioHora { get; set; }
    }
}
