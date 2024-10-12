using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Inventario
    {
        [Required(ErrorMessage = "El id del inventario es requerido")] //Valida que no se dejen campos en blanco
        public int IdInventario { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")] //Valida que no se dejen campos en blanco
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El tipo de máquina es requerido")] //Valida que no se dejen campos en blanco
        public string TipoMaquina { get; set; }
        [Required(ErrorMessage = "Las horas de uso actuales son requeridas")] //Valida que no se dejen campos en blanco
        public float HorasActuales { get; set; }
        [Required(ErrorMessage = "Las horas de uso máximas al día son requeridas")] //Valida que no se dejen campos en blanco
        public float HorasMaximas { get; set; }
        [Required(ErrorMessage = "Las horas de uso para dar mantenimiento son requeridas")] //Valida que no se dejen campos en blanco
        public float HorasMantenimiento { get; set; }      
    }
}
