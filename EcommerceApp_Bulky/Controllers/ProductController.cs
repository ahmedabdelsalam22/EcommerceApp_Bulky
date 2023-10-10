using AutoMapper;
using Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository;
using Ecommerce_Bulky.Models.Dtos;
using Ecommerce_Bulky.Models.Models;
using EcommerceApp_Bulky.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            // display categories
            IEnumerable<SelectListItem> categoryList = _unitOfWork.categoryRepository.GetAll()
                .Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() });


            var productVM = new ProductVM() 
            { 
                CategoriesList = categoryList ,
                ProductcreateDto = new ProductCreateDto()
            };


            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVM productVM) 
        {
            if (productVM.ProductcreateDto == null) 
            {
                ModelState.AddModelError("","fill data!");
            }
            if (ModelState.IsValid) 
            {
                Product product = _mapper.Map<Product>(productVM.ProductcreateDto);

                await _unitOfWork.productRepository.CreateAsync(product);
                await _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id) 
        {
            if (id == 0 || id == null) 
            {
                ModelState.AddModelError("", "id must not be null or zero!");
            }
            Product product = await _unitOfWork.productRepository.GetByIdAsync(filter:x=>x.Id == id);

            ProductUpdateDto productUpdateDto = _mapper.Map<ProductUpdateDto>(product);

            return View(productUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto updateDto)
        {
            if (updateDto == null) 
            {
                ModelState.AddModelError("", "fill data!");
            }
            if(ModelState.IsValid)
            {
                Product productToDb = _mapper.Map<Product>(updateDto);
                _unitOfWork.productRepository.Update(productToDb);
                await _unitOfWork.Save();
                TempData["success"] = "product updated successfully";
                return RedirectToAction("Index");
            }
            return View(updateDto);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                ModelState.AddModelError("", "id must not be null or zero!");
            }
            Product product = await _unitOfWork.productRepository.GetByIdAsync(filter: x => x.Id == id);

            _unitOfWork.productRepository.Remove(product);
            await _unitOfWork.Save();
            TempData["success"] = "product removed successfully";
            return RedirectToAction("Index");
        }
    }
}
