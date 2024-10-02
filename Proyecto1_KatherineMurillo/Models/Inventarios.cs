using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Inventarios
    {
        [Required(ErrorMessage = "La Id del inventario es requerida")]
        [Display(Name = "ID del inventario")]
        public int IdInventario { get; set; }
        public string Descripcion { get; set; }
        public string TipoMaquina { get; set; }
        public float HorasActuales { get; set; }
        public float HorasMaximas { get; set; }
        public float HorasMantenimiento { get; set; }
        
    }
}
