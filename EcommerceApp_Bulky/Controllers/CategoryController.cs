using Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository;
using EcommerceApp_Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp_Bulky.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _unitOfWork.categoryRepository.GetAllAsync(tracked:false);

            return View();
        }
    }
}
