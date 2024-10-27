namespace Proyecto1_KatherineMurillo.Models
{
    public class cls_Product
    {
        #region VARIABLES PÚBLICAS
        public int iId { get; set; }
        public string sNombre { get; set; }
        public cls_Product()
        {
            iId = 0;
            sNombre = string.Empty;
        }
        #endregion
    }
}
