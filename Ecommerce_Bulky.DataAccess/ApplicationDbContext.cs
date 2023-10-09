using Ecommerce_Bulky.Models.Models;
using EcommerceApp_Bulky.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Bulky.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<Product>().HasData(
                new Product() { 
                    Id= 1,
                    Title= "True Girt",
                    Description= "Girt was also shortlisted for the 2014 Australian " +
                    "Book Industry Awards (ABIA), the New South Wales" +
                    " Premier's Literary Awards, the Australian Book Design" +
                    " Awards and was the only non-fiction book shortlisted" +
                    " for the ABA Nielsen BookData 2014 Booksellers Choice Award.",
                    ISBN="5265842",
                    Author= "David Hunt",
                    ListPrice=99,
                    Price=90,
                    Price50=85,
                    Price100=80,
                    CategoryId=23,
                    ImageUrl=""
                },
                new Product()
                {
                    Id= 2,
                    Title = "Predator's Gold",
                    Description = "This is the second book in the Hungry Ciy Chronicles," +
                    " the first being \"Mortal Engines\". It was a very good sequel to" +
                    " book number 1 which I enjoyed just a bit more, but this was also" +
                    " very good. If you enjoy science ficiton, definitely pick this up." +
                    " This is a middle-grade book, however. I would put it in the same " +
                    "writing style category as the Percy Jackson books, but with " +
                    "a British tone. Highly enjoyable.",
                    ISBN = "85965874",
                    Author = "Philip Reeve",
                    ListPrice = 110,
                    Price = 103,
                    Price50 = 98,
                    Price100 = 89,
                    CategoryId = 24,
                    ImageUrl=""
                }
                );
        }

        
    }
}
