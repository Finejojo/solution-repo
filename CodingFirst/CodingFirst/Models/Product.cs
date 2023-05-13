using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodingFirst.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Provide the Product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Provide the Product Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Provide the Product Quantity")]
        public int Qty { get; set; }

        
    }
    public class CodeFirstContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}