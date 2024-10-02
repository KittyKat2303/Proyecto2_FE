using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Mantenimiento
    {
        [Required(ErrorMessage = "La Id del mamtenimiento es requerida")]
        [Display(Name = "ID del Mantenimiento")]
        public int IdMantenimiento { get; set; }
        public DateTime FechaEjecutado { get; set; }
        public DateTime FechaAgendado { get; set; }
        public float MetrosPropiedad { get; set; }
        public float MetrosCercaViva { get; set; }
        public int DiasSinChapia { get; set; }
        public DateTime FechaOtraChapia { get; set; }
        public string TipoZacate { get; set; }
        public string AplicacionProducto { get; set; }
        public string ProductoAplicado { get; set; }
        public float CostoChapia { get; set; }
        public float CostoAplicacionProducto { get; set; }
        public string EstadoMantenimiento { get; set; }
    }
}
