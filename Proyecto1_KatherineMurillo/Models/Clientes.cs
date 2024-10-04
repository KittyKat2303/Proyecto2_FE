using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Clientes
    {
        [Required(ErrorMessage = "La identificación del cliente es requerida")]
        //[Display(Name = "Identificación")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre completo es requerido")]
        //[Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La provincia es requerida")]
        //[Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El cantón es requerido")]
        //[Display(Name = "Cantón")]
        public string Canton { get; set; }

        [Required(ErrorMessage = "El distrito es requerido")]
        //[Display(Name = "Distrito")]
        public string Distrito { get; set; }

        [Required(ErrorMessage = "La dirección exacta es requerida")]
       // [Display(Name = "Dirección exacta")]
        public string DireccionExacta { get; set; }

        [Required(ErrorMessage = "La preferencia de mantenimiento en invierno es requerida")]
       // [Display(Name = "Mantenimiento de invierno")]
        public int MantenimientoInvierno { get; set; }

        [Required(ErrorMessage = "La preferencia de mantenimiento en verano es requerida")]
        //[Display(Name = "Mantenimiento de verano")]
        public int MantenimientoVerano { get; set; }
    }
}
