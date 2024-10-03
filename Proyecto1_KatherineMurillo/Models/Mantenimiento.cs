using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Mantenimiento
    {
        [Required(ErrorMessage = "El id del mamtenimiento es requerido")]
        [Display(Name = "Id del mantenimiento")]
        public int IdMantenimiento { get; set; }
        [Required(ErrorMessage = "La fecha de ejecutado es requerida")]
        [Display(Name = "Fecha de ejecutado")]
        public DateTime FechaEjecutado { get; set; }
        [Required(ErrorMessage = "La fecha de agendado es requerida")]
        [Display(Name = "Fecha de agendado")]
        public DateTime FechaAgendado { get; set; }
        [Required(ErrorMessage = "La cantidad de metros cuadrados de la propiedad es requerida")]
        [Display(Name = "Metros cuadrados de la propiedad")]
        public float MetrosPropiedad { get; set; }
        [Required(ErrorMessage = "La cantidad de metros cuadrados de cerca viva es requerida")]
        [Display(Name = "Metros cuadrados de cerca viva")]
        public float MetrosCercaViva { get; set; }
        [Required(ErrorMessage = "La cantidad de días sin chapia es requerida")]
        [Display(Name = "Cantidad de días sin chapia")]
        public int DiasSinChapia { get; set; }
        [Required(ErrorMessage = "La fecha aproximada de la siguiente chapia es requerida")]
        [Display(Name = "Fecha aproximada de la siguiente chapia")]
        public DateTime FechaOtraChapia { get; set; }
        [Required(ErrorMessage = "El tipo de zacate es requerido")]
        [Display(Name = "Tipo de zacate")]
        public string TipoZacate { get; set; }
        [Required(ErrorMessage = "Si se le ha aplicado algún producto es requerido")]
        [Display(Name = "Si se le ha aplicado algún producto")]
        public string AplicacionProducto { get; set; }
        [Required(ErrorMessage = "El producto aplicado es requerido")]
        [Display(Name = "Producto aplicado")]
        public string ProductoAplicado { get; set; }
        [Required(ErrorMessage = "El costo de la chapia es requerido")]
        [Display(Name = "Costo de la chapia")]
        public float CostoChapia { get; set; }
        [Required(ErrorMessage = "El costo de la aplicación es requerido")]
        [Display(Name = "Costo de la aplicación")]
        public float CostoAplicacionProducto { get; set; }
        [Required(ErrorMessage = "El estado del mantenimiento es requerido")]
        [Display(Name = "El estado del mantenimiento")]
        public string EstadoMantenimiento { get; set; }
    }
}
