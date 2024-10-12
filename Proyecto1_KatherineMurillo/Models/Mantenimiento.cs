using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Mantenimiento
    {
        [Required(ErrorMessage = "El id del mamtenimiento es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "ID de mantenimiento")]
        public int IdMantenimiento { get; set; }
        [Required(ErrorMessage = "El id del cliente es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "ID del cliente")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "La fecha de ejecutado es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Fecha de ejecutado")]
        public DateTime FechaEjecutado { get; set; }
        [Required(ErrorMessage = "La fecha de agendado es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Fecha de agendado")]
        public DateTime FechaAgendado { get; set; }
        [Required(ErrorMessage = "La cantidad de metros cuadrados de la propiedad es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Metros de la propiedad")]
        public float MetrosPropiedad { get; set; }
        [Required(ErrorMessage = "La cantidad de metros cuadrados de cerca viva es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Metros de cerca viva")]
        public float MetrosCercaViva { get; set; }
        [Required(ErrorMessage = "La cantidad de días sin chapia es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Días sin chapia")]
        public string DiasSinChapia { get; set; }
        [Required(ErrorMessage = "La fecha aproximada de la siguiente chapia es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Fecha de la siguiente chapia")]
        public string FechaOtraChapia { get; set; }
        [Required(ErrorMessage = "El tipo de zacate es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Tipo de zacate")]
        public string TipoZacate { get; set; }
        [Required(ErrorMessage = "Si se le ha aplicado algún producto es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Aplicación de producto")]
        public string AplicacionProducto { get; set; }
        [Required(ErrorMessage = "El producto aplicado es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Producto aplicado")]
        public string ProductoAplicado { get; set; }
        [Required(ErrorMessage = "El costo de la chapia es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Costo de la chapia")]
        public float CostoChapia { get; set; }
        [Required(ErrorMessage = "El costo de la aplicación es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Costo de la aplicación del producto")]
        public float CostoAplicacionProducto { get; set; }
        [Required(ErrorMessage = "El estado del mantenimiento es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Estado del mantenimiento")]
        public string EstadoMantenimiento { get; set; }
    }
}
