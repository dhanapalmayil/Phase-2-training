using Microsoft.AspNetCore.Mvc;
using MVC_ADO.Data_Access;
using MVC_ADO.Models;

namespace MVC_ADO.Controllers
{
    public class ProductController : Controller
    {
        ProductDataAccess pda=new ProductDataAccess();
        public IActionResult Index()
        {
            List<ProductModel> list= pda.Fetch();
            return View(list);
        }
        public IActionResult Search()
        {
            List<ProductModel> list = pda.Fetch();
            return View(list);
        }
    }
}
