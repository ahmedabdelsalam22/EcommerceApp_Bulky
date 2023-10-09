using EcommerceApp_Bulky.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Bulky.Models.Dtos
{
    public class ProductCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public double ListPrice { get; set; }
        public double Price { get; set; }
        public double Price50 { get; set; }
        public double Price100 { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
