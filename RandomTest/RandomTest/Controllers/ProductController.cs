using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomTest.Data;
using RandomTest.Model;

namespace RandomTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext dbContext;

        public ProductController(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await dbContext.Products.ToListAsync();
            if(products == null) return NotFound();
            return Ok(products);
        }

        [HttpGet("{id: guid}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await dbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(product == null) return NotFound();
            
            return Ok(product);
        }
        [HttpPost("{id: guid}")]
        public async Task<IActionResult> AddProduct(Guid id, AddProduct addProduct)
        {
            var product = new Product();
            product.Id = Guid.NewGuid();
            product.Name = addProduct.Name;
            product.Price = addProduct.Price;
            product.Quantity = addProduct.Quantity;
            product.UserId = addProduct.UserId;
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return Ok(product);
        }
        
    }
}
