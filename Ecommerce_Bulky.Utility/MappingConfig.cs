using AutoMapper;
using Ecommerce_Bulky.Models.Dtos;
using Ecommerce_Bulky.Models.Models;
using EcommerceApp_Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Bulky.Utility
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto,Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<Product,ProductDto>();
        }
    }
}
