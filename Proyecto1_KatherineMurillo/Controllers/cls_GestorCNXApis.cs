using Proyecto1_KatherineMurillo.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class cls_GestorCNXApis
    {
        #region VARIABLE PÚBLICAS
        public HttpClient hcCNXApi;
        public cls_GestorCNXApis() 
        {
            hcCNXApi = new HttpClient();
            EstablecerConexion();
        }
        #endregion

        #region METODOS

        #region PRIVADOS
        private void EstablecerConexion()                                // AL OBJ CONEXIONAPIS LE DEBO DE ESTABLECER CIERTOS DATOS
        {                                                               // INDICAR QUE EL TRASLADO DE DATOS VA EN FORMATO JSON Y QUE CUAL ES LA DIRECCION BASE AL QUE VA APUNTAR
            hcCNXApi.BaseAddress = new Uri("http://localhost:35464");  // EL URI AGARRA LA RUTA BASE  DEL API PUEDE SER IIS O DEL HOST API
            hcCNXApi.DefaultRequestHeaders.Accept.Clear();            //SE LIMPIAN LOS VALORES POR DEFECTO   
            hcCNXApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region PUBLICOS

        #region PRODUCT
        public async Task<List<cls_Product>> ListarProduct()
        {
            List<cls_Product> Obj_lstResultado = new List<cls_Product>();
            string _sRutaAPI = @"api/Product/ListarProduct";

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Product>>(jsonstring);
            }
            return Obj_lstResultado;
        }
        public async Task<List<cls_Product>> ConsultarProduct(cls_Product P_Entidad)
        {
            List<cls_Product> Obj_lstResultado = new List<cls_Product>();
            string _sRutaAPI = @"api/Product/ConsultarProduct";

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.iId.ToString());
            
            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Product>>(jsonstring);
            }
            return Obj_lstResultado;
        }

        public async Task<bool> AgregarProduct(cls_Product P_Entidad)
        {
            string _sRutaAPI = @"api/Product/AgregarProduct";    //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PostAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarProduct(cls_Product P_Entidad)
        {
            string _sRutaAPI = @"api/Product/ModificarProduct";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.iId.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PutAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarProduct(cls_Product P_Entidad)
        {
            string _sRutaAPI = @"api/Product/EliminarProduct";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.iId.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.DeleteAsync(_sRutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region EMPLEADOS

        #endregion

        #endregion

        #endregion
    }
}
