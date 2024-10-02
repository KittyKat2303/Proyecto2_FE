using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Clientes
    {
        [Required(ErrorMessage = "La identificación del cliente es requerida")]
        [Display(Name = "Identificación")]
        public int Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string DireccionExacta { get; set; }
        public string MantenimientoInvierno { get; set; }
        public string MantenimientoVerano { get; set; }
    }
}
