using AutoMapper;
using Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository;
using Ecommerce_Bulky.Models.Dtos;
using Ecommerce_Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp_Bulky.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _unitOfWork.productRepository.GetAllAsync();

            IEnumerable<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(products);

            return View(productDtos);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto createDto) 
        {
            if (createDto == null) 
            {
                ModelState.AddModelError("","fill data!");
            }
            if (ModelState.IsValid) 
            {
                Product product = _mapper.Map<Product>(createDto);

                await _unitOfWork.productRepository.CreateAsync(product);
                await _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
