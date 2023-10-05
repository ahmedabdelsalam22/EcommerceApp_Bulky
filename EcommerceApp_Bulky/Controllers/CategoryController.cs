using AutoMapper;
using Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository;
using Ecommerce_Bulky.Models.Dtos;
using EcommerceApp_Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp_Bulky.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _unitOfWork.categoryRepository.GetAllAsync(tracked:false);

            List<CategoryDto> categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);

            return View(categoriesDtos);
        }
    }
}
