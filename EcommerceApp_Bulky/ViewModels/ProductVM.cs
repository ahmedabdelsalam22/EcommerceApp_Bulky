using Ecommerce_Bulky.Models.Dtos;
using Ecommerce_Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceApp_Bulky.Web.ViewModels
{
    public class ProductVM
    {
        public ProductCreateDto ProductcreateDto { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoriesList { get; set; }

    }
}
