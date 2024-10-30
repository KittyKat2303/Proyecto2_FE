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
     
        #region PRIVADOS
        private void EstablecerConexion()                                // AL OBJ CONEXIONAPIS LE DEBO DE ESTABLECER CIERTOS DATOS
        {                                                               // INDICAR QUE EL TRASLADO DE DATOS VA EN FORMATO JSON Y QUE CUAL ES LA DIRECCION BASE AL QUE VA APUNTAR
            hcCNXApi.BaseAddress = new Uri("http://localhost:35464");  // EL URI AGARRA LA RUTA BASE  DEL API PUEDE SER IIS O DEL HOST API
            hcCNXApi.DefaultRequestHeaders.Accept.Clear();            //SE LIMPIAN LOS VALORES POR DEFECTO   
            hcCNXApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region MÉTODOS

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
        public async Task<List<Empleados>> ListarEmpleados()
        {
            List<Empleados> Obj_lstResultado = new List<Empleados>();
            string _sRutaAPI = @"api/Empleados/ListarEmpleados";

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<Empleados>>(jsonstring);
            }
            return Obj_lstResultado;
        }
        public async Task<List<Empleados>> ConsultarEmpleados(Empleados P_Entidad)
        {
            List<Empleados> Obj_lstResultado = new List<Empleados>();
            string _sRutaAPI = @"api/Empleados/ConsultarEmpleados";

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.iCedula.ToString());

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<Empleados>>(jsonstring);
            }
            return Obj_lstResultado;
        }
        public async Task<bool> AgregarEmpleados(Empleados P_Entidad)
        {
            string _sRutaAPI = @"api/Empleados/AgregarEmpleados";    //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PostAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarEmpleados(Empleados P_Entidad)
        {
            string _sRutaAPI = @"api/Empleados/ModificarEmpleados";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.iCedula.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PutAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarEmpleados(Empleados P_Entidad)
        {
            string _sRutaAPI = @"api/Empleados/EliminarEmpleados";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.iCedula.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.DeleteAsync(_sRutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region INVENTARIO
        public async Task<List<Inventario>> ListarInventario()
        {
            List<Inventario> Obj_lstResultado = new List<Inventario>();
            string _sRutaAPI = @"api/Inventario/ListarInventario";

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<Inventario>>(jsonstring);
            }
            return Obj_lstResultado;
        }
        public async Task<List<Inventario>> ConsultarInventario(Inventario P_Entidad)
        {
            List<Inventario> Obj_lstResultado = new List<Inventario>();
            string _sRutaAPI = @"api/Inventario/ConsultarInventario";

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.IdInventario.ToString());

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<Inventario>>(jsonstring);
            }
            return Obj_lstResultado;
        }
        public async Task<bool> AgregarInventario(Inventario P_Entidad)
        {
            string _sRutaAPI = @"api/Inventario/AgregarInventario";    //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PostAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarInventario(Inventario P_Entidad)
        {
            string _sRutaAPI = @"api/Inventario/ModificarInventario";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.IdInventario.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PutAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarInventario(Inventario P_Entidad)
        {
            string _sRutaAPI = @"api/Inventario/EliminarInventario";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.IdInventario.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.DeleteAsync(_sRutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region CLIENTES
        public async Task<List<Clientes>> ListarClientes()
        {
            List<Clientes> Obj_lstResultado = new List<Clientes>();
            string _sRutaAPI = @"api/Clientes/ListarClientes";

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<Clientes>>(jsonstring);
            }
            return Obj_lstResultado;
        }
        public async Task<List<Clientes>> ConsultarEmpleado(Clientes P_Entidad)
        {
            List<Clientes> Obj_lstResultado = new List<Clientes>();
            string _sRutaAPI = @"api/Clientes/ConsultarClientes";

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.Identificacion.ToString());

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<Clientes>>(jsonstring);
            }
            return Obj_lstResultado;
        }
        public async Task<bool> AgregarClientes(Clientes P_Entidad)
        {
            string _sRutaAPI = @"api/Clientes/AgregarClientes";    //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PostAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarClientes(Clientes P_Entidad)
        {
            string _sRutaAPI = @"api/Clientes/ModificarClientes";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.Identificacion.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PutAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarClientes(Clientes P_Entidad)
        {
            string _sRutaAPI = @"api/Clientes/EliminarClientes";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.Identificacion.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.DeleteAsync(_sRutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region MANTENIMIENTO
        public async Task<List<Mantenimiento>> ListarMantenimiento()
        {
            List<Mantenimiento> Obj_lstResultado = new List<Mantenimiento>();
            string _sRutaAPI = @"api/Mantenimiento/ListarMantenimiento";

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<Mantenimiento>>(jsonstring);
            }
            return Obj_lstResultado;
        }
        public async Task<List<Mantenimiento>> ConsultarMantenimiento(Mantenimiento P_Entidad)
        {
            List<Mantenimiento> Obj_lstResultado = new List<Mantenimiento>();
            string _sRutaAPI = @"api/Mantenimiento/ConsultarMantenimiento";

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.IdMantenimiento.ToString());

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                Obj_lstResultado = JsonSerializer.Deserialize<List<Mantenimiento>>(jsonstring);
            }
            return Obj_lstResultado;
        }
        public async Task<bool> AgregarMantenimiento(Mantenimiento P_Entidad)
        {
            string _sRutaAPI = @"api/Mantenimiento/AgregarMantenimiento";    //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PostAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarMantenimiento(Mantenimiento P_Entidad)
        {
            string _sRutaAPI = @"api/Mantenimiento/ModificarMantenimiento";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.IdMantenimiento.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PutAsJsonAsync(_sRutaAPI, P_Entidad);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarMantenimiento(Mantenimiento P_Entidad)
        {
            string _sRutaAPI = @"api/Mantenimiento/EliminarMantenimiento";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.IdMantenimiento.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.DeleteAsync(_sRutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region REPORTES

        #endregion
        #endregion
    }
}
