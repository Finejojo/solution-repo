using System.ComponentModel.DataAnnotations.Schema;

namespace RandomTest.Model
{
    public class AddProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
    }
}
