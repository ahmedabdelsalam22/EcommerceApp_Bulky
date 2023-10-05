using AutoMapper;
using Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository;
using Ecommerce_Bulky.Models.Dtos;
using EcommerceApp_Bulky.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto createDto) 
        {
            if (ModelState.IsValid) 
            {
                Category categoryToDb = _mapper.Map<Category>(createDto);

                await _unitOfWork.categoryRepository.CreateAsync(categoryToDb);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(createDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id) 
        {
            Category category = await _unitOfWork.categoryRepository.GetByIdAsync(filter: x => x.Id == id);

            CategoryUpdateDto categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(category);
            return View(categoryUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto dto) 
        {
            if (ModelState.IsValid)
            {
                Category categoryToDb = _mapper.Map<Category>(dto);

                _unitOfWork.categoryRepository.Update(categoryToDb);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _unitOfWork.categoryRepository.GetByIdAsync(filter: x => x.Id == id);
            _unitOfWork.categoryRepository.Remove(category);
            await _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
