using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class Mantenimiento
    {
        [Required(ErrorMessage = "El id del mamtenimiento es requerido")] //Valida que no se dejen campos en blanco
        public int IdMantenimiento { get; set; }
        [Required(ErrorMessage = "El id del cliente es requerido")] //Valida que no se dejen campos en blanco
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "La fecha de ejecutado es requerida")] //Valida que no se dejen campos en blanco
        public DateTime FechaEjecutado { get; set; }
        [Required(ErrorMessage = "La fecha de agendado es requerida")] //Valida que no se dejen campos en blanco
        public DateTime FechaAgendado { get; set; }
        [Required(ErrorMessage = "La cantidad de metros cuadrados de la propiedad es requerida")] //Valida que no se dejen campos en blanco
        public float MetrosPropiedad { get; set; }
        [Required(ErrorMessage = "La cantidad de metros cuadrados de cerca viva es requerida")] //Valida que no se dejen campos en blanco
        public float MetrosCercaViva { get; set; }
        [Required(ErrorMessage = "La cantidad de días sin chapia es requerida")] //Valida que no se dejen campos en blanco
        public string DiasSinChapia { get; set; }
        [Required(ErrorMessage = "La fecha aproximada de la siguiente chapia es requerida")] //Valida que no se dejen campos en blanco
        public string FechaOtraChapia { get; set; }
        [Required(ErrorMessage = "El tipo de zacate es requerido")] //Valida que no se dejen campos en blanco
        public string TipoZacate { get; set; }
        [Required(ErrorMessage = "Si se le ha aplicado algún producto es requerido")] //Valida que no se dejen campos en blanco
        public string AplicacionProducto { get; set; }
        [Required(ErrorMessage = "El producto aplicado es requerido")] //Valida que no se dejen campos en blanco
        public string ProductoAplicado { get; set; }
        [Required(ErrorMessage = "El costo de la chapia es requerido")] //Valida que no se dejen campos en blanco
        public float CostoChapia { get; set; }
        [Required(ErrorMessage = "El costo de la aplicación es requerido")] //Valida que no se dejen campos en blanco
        public float CostoAplicacionProducto { get; set; }
        [Required(ErrorMessage = "El estado del mantenimiento es requerido")] //Valida que no se dejen campos en blanco
        public string EstadoMantenimiento { get; set; }
    }
}
