using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Inventarios
    {
        [Required(ErrorMessage = "El id del inventario es requerido")]
        [Display(Name = "ID del inventario")]
        public int IdInventario { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El tipo de máquina es requerido")]
        [Display(Name = "Tipo de máquina")]
        public string TipoMaquina { get; set; }
        [Required(ErrorMessage = "Las horas de uso actuales son requeridas")]
        [Display(Name = "Horas de uso actuales")]
        public float HorasActuales { get; set; }
        [Required(ErrorMessage = "Las horas de uso máximas al día son requeridas")]
        [Display(Name = "Horas de uso máximas al día")]
        public float HorasMaximas { get; set; }
        [Required(ErrorMessage = "Las horas de uso para dar mantenimiento son requeridas")]
        [Display(Name = "Horas de uso para dar mantenimiento")]
        public float HorasMantenimiento { get; set; }
        
    }
}
