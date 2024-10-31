using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class cls_Clientes
    {
        #region VARIABLES PUBLICAS
        [Required(ErrorMessage = "La identificación del cliente es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Identificación")]
        public int Identificacion { get; set; }
        [Required(ErrorMessage = "El nombre completo es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "La provincia es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "El cantón es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Cantón")]
        public string Canton { get; set; }
        [Required(ErrorMessage = "El distrito es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }
        [Required(ErrorMessage = "La dirección exacta es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Dirección exacta")]                                                              
        public string DireccionExacta { get; set; }
        [Required(ErrorMessage = "La preferencia de mantenimiento en invierno es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Mantenimiento en invierno")]
        public int MantenimientoInvierno { get; set; }
        [Required(ErrorMessage = "La preferencia de mantenimiento en verano es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Mantenimiento en verano")]
        public int MantenimientoVerano { get; set; }
        public cls_Clientes()
        {
            Identificacion = 0;
            NombreCompleto = string.Empty;
            Provincia = string.Empty;
            Canton = string.Empty;
            Distrito = string.Empty;
            DireccionExacta = string.Empty;
            MantenimientoInvierno = 0;
            MantenimientoVerano = 0;
        }
        #endregion
    }
}
