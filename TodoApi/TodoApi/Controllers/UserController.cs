using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Model;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TodoDbContext dbContext;

        public UserController(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> signup(signupModel signup)
        {
            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = signup.Name,
                Email = signup.Email,
                Password = signup.Password,
                Role = signup.Role,
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok("Successfully Registered");
        }

        [HttpPost]
        public async Task<IActionResult> signin(signinModel signin)
        {
            var user = await dbContext.Users.Where(u => u.Email == signin.Email && u.Password == signin.Password).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("User not Found");
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);
            
            if (user == null)
            {
                return NotFound("User not Found");
            }
            return Ok(user);
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAllUsers(Guid id)
        {
            var find = await dbContext.Users.FindAsync(id);
            if(find == null || find.Role.ToLower() != "admin") { 
                return Unauthorized("Access denied");
            }
            var users = await dbContext.Users.Where(u => u.Role != "admin").ToListAsync();
            return Ok(users);
        }
        

        [HttpGet]
        [Route("{id:guid}/{search}")]
        public async Task<IActionResult> GetAllUsers(Guid id, string search)
        {
            var find = await dbContext.Users.FindAsync(id);
            if (find == null || find.Role.ToLower() != "admin")
            {
                return Unauthorized("Access denied");
            }
            var users = await dbContext.Users.Where(u => u.Name.ToLower().Contains(search.ToLower()) && u.Role != "admin").ToListAsync();
            return Ok(users);
        }
        
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserModel user)
        {
            var find = await dbContext.Users.FindAsync(id);
            if(find == null)
            {
                return NotFound("Unable to Update user");
            }
            find.Name = user.Name;
            find.Email = user.Email;
            find.Role = user.Role;
            find.Password = user.Password;
            dbContext.SaveChanges();
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var find = await dbContext.Users.FindAsync(id);
            if (find == null)
            {
                return NotFound("Unable to Delete user");
            }
            dbContext.Remove(find);
            dbContext.SaveChanges();

            return Ok("Successfully deleted");
        }
        
    }
}
