using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class ProductController : Controller
    {
        #region VARIABLE PRIVADA
    
        #endregion
        #region EVENTO DE APERTURA VIEW
        public async Task<IActionResult> Index()
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();
            List<cls_Product> lstResultado = await Obj_CNX.ListarProduct();
            return View(lstResultado);
        }
        public IActionResult AbrirCrearProduct() 
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarProduct(int _iId_Product)  
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Product> _lstResultado = await Obj_Gestor.ConsultarProduct(new cls_Product { iId = _iId_Product });
            cls_Product Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarProduct(int _iId_Product)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.EliminarProduct(new cls_Product { iId = _iId_Product });
            return RedirectToAction("Index", "Product");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertProduct(cls_Product Obj_Product)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.AgregarProduct(Obj_Product);
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(cls_Product Obj_Product)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.ModificarProduct(Obj_Product);
            return RedirectToAction("Index", "Product");
        }

        #endregion
    }
}
