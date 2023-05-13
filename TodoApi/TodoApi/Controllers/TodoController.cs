using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Model;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext dbContext;

        public TodoController(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTodos(Guid id)
        {
            /*
            var find = await dbContext.Users.FindAsync(id);
            if(find == null)
            {
                return Unauthorized("Access Denied, cannot access Todos");
            }
            */
            var todos = await dbContext.Todos.Where(todo => todo.User.Id == id).ToListAsync();
            return Ok(todos);
        }
        [HttpGet("{page}")]
        public async Task<IActionResult> GetTodoByPage(int page)
        {
            if(dbContext.Todos == null)
            {
                return NotFound();
            }

            var noOfTodo = 5f;
            var noOfPages = Math.Ceiling(dbContext.Todos.Count() / noOfTodo);
            var todo = await dbContext.Todos
                        .Skip((page - 1) * (int)noOfTodo)
                        .Take((int)noOfTodo)
                        .ToListAsync();
            var paginatedTodo = new TodoPageModel
            {
                Todo = todo,
                CurrentPage = page,
                TotalPage = (int)noOfPages

            };

            return Ok(paginatedTodo);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            /*
            var find = await dbContext.Users.FindAsync(UserId);
            if (find == null)
            {
                return Unauthorized("Access Denied, cannot access Todos");
            }
            */
            var todo = await dbContext.Todos.FindAsync(id);
            if(todo == null)
            {
                return NotFound("Todo Not found");
            }
            return Ok(todo);
        }

        [HttpGet]
        [Route("{id:guid}/{search}")]
        public async Task<IActionResult> GetTodoByWord(Guid id, string search)
        {
            var todo = await dbContext.Todos.Where(t => t.Task.Contains(search) && t.UserId == id).ToListAsync();
            return Ok(todo);
        }

        [HttpPost]
        [Route("{id:guid}")]
        public async Task<IActionResult> AddTodo(Guid id, AddTodoModel addTodo)
        {
            /*
            var find = await dbContext.Users.FindAsync(id);
            if(find == null)
            {
                return Unauthorized("Login before adding todo");
            }
            */
            var todo = new TodoModel
            {
                Id = Guid.NewGuid(),
                Task = addTodo.Task,
                Description = addTodo.Description,
                Category = addTodo.Category,
                Completed = addTodo.Completed,
                EndDate = addTodo.EndDate,
                CreatedAt = addTodo.CreatedAt,
                UserId = id
            };
            await dbContext.AddAsync(todo);
            await dbContext.SaveChangesAsync();

            return Ok(todo);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTodo(Guid id, AddTodoModel add)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if(todo == null)
            {
                return NotFound("Unable to update");
            }
            todo.Task = add.Task;
            todo.Description = add.Description;
            todo.Category = add.Category;
            todo.Completed = add.Completed;
            todo.EndDate = add.EndDate;
            await dbContext.SaveChangesAsync();

            return Ok(todo);
        }
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if(todo == null)
            {
                return Unauthorized("Unable to delete task");
            }
            dbContext.Todos.Remove(todo);
            await dbContext.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

    }
}
