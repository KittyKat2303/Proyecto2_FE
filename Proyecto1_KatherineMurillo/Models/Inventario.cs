using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Inventario
    {
        [Required(ErrorMessage = "El ID del inventario es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "ID de inventario")]
        public int IdInventario { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El tipo de máquina es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Tipo de máquina")]
        public string TipoMaquina { get; set; }
        [Required(ErrorMessage = "Las horas de uso actuales son requeridas")] //Valida que no se dejen campos en blanco
        [Display(Name = "Horas de uso actuales")]
        public float HorasActuales { get; set; }
        [Required(ErrorMessage = "Las horas de uso máximas al día son requeridas")] //Valida que no se dejen campos en blanco
        [Display(Name = "Horas de uso máximas")]
        public float HorasMaximas { get; set; }
        [Required(ErrorMessage = "Las horas de uso para dar mantenimiento son requeridas")] //Valida que no se dejen campos en blanco
        [Display(Name = "Horas de uso para mantenimiento")]
        public float HorasMantenimiento { get; set; }      
    }
}
