using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        [MaxLength(255)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
