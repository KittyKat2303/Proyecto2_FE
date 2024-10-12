using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Clientes
    {
        [Required(ErrorMessage = "La identificación del cliente es requerida")] //Valida que no se dejen campos en blanco
        public int Identificacion { get; set; }
        [Required(ErrorMessage = "El nombre completo es requerido")] //Valida que no se dejen campos en blanco
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "La provincia es requerida")] //Valida que no se dejen campos en blanco
        public string Provincia { get; set; }
        [Required(ErrorMessage = "El cantón es requerido")] //Valida que no se dejen campos en blanco
        public string Canton { get; set; }
        [Required(ErrorMessage = "El distrito es requerido")] //Valida que no se dejen campos en blanco
        public string Distrito { get; set; }
        [Required(ErrorMessage = "La dirección exacta es requerida")] //Valida que no se dejen campos en blanco                                                              
        public string DireccionExacta { get; set; }
        [Required(ErrorMessage = "La preferencia de mantenimiento en invierno es requerida")] //Valida que no se dejen campos en blanco                                                                                          
        public int MantenimientoInvierno { get; set; }
        [Required(ErrorMessage = "La preferencia de mantenimiento en verano es requerida")] //Valida que no se dejen campos en blanco
        public int MantenimientoVerano { get; set; }
    }
}
