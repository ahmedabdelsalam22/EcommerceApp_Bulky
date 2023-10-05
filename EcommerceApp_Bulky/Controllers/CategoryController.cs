using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp_Bulky.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
