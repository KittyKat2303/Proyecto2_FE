using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Proyecto1_KatherineMurillo.Models
{
    public class Empleados
    {        
        [Required(ErrorMessage = "La cédula es requerida")] //Valida que no se dejen campos en blanco
        public int Cedula { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")] //Valida que no se dejen campos en blanco
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "La lateralidad es requerida")] //Valida que no se dejen campos en blanco
        public string Lateralidad { get; set; }
        [Required(ErrorMessage = "La fecha de ingreso es requerida")] //Valida que no se dejen campos en blanco
        public DateTime FechaIngreso { get; set; }
        [Required(ErrorMessage = "El salario por hora es requerida")] //Valida que no se dejen campos en blanco
        public float SalarioHora { get; set; }
    }
}
