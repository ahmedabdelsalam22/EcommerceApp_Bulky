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
        public async Task<IActionResult> Upsert(int? id) 
        {
            // display categories
            IEnumerable<SelectListItem> categoryList = _unitOfWork.categoryRepository.GetAll()
                .Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() });


            var productVm = new ProductVM() 
            { 
                CategoriesList = categoryList ,
                ProductDto = new ProductDto()
            };

            if (id == null || id == 0)
            {
                // Create 
                return View(productVm);
            }
            else 
            {
                // Update
                Product product = await _unitOfWork.productRepository.GetByIdAsync(filter: x => x.Id == id);

                ProductDto productDto = _mapper.Map<ProductDto>(product);

                productVm.ProductDto = productDto;

                return View(productVm);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ProductVM productVM, IFormFile? file) 
        {
            if (productVM.ProductDto.Id == 0 || productVM.ProductDto.Id == null)
            {
                if (ModelState.IsValid)
                {
                    Product product = _mapper.Map<Product>(productVM.ProductDto);

                    await _unitOfWork.productRepository.CreateAsync(product);
                    await _unitOfWork.Save();
                    TempData["success"] = "Product Created Successfully";
                    return RedirectToAction("Index");
                }
            }
            else 
            {
                if (productVM.ProductDto == null) 
                {
                    ModelState.AddModelError("", "fill data!");
                }
                Product productToDb = _mapper.Map<Product>(productVM.ProductDto);
                _unitOfWork.productRepository.Update(productToDb);
                await _unitOfWork.Save();
                TempData["success"] = "product updated successfully";
                return RedirectToAction("Index");
            }

            return View(productVM.ProductDto);
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
