using ASPNETMVCCORE.Data;
using ASPNETMVCCORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ASPNETMVCCORE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCDbContext _dbContext;
        public EmployeeController(MVCDbContext mvcDbContext)
        {
            _dbContext = mvcDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _dbContext.Employees.ToListAsync<Employee>();
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeView employee)
        {
            var emp = new Employee
            {
                Id = new Guid(),
                Name = employee.Name,
                Email = employee.Email,
                DaeteOFBirth = employee.DaeteOFBirth,
                Department = employee.Department,
                Salary = employee.Salary,
            };
            await _dbContext.Employees.AddAsync(emp);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            
            return View(employee);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            var empl = await _dbContext.Employees.FindAsync(employee.Id);
            if(empl != null)
            {
                empl.Name = employee.Name;
                empl.Email = employee.Email;
                empl.DaeteOFBirth = employee.DaeteOFBirth;
                empl.Department = employee.Department;
                empl.Salary = employee.Salary;

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            TempData["error"] = "Unable to Update Employee Details";
            return View(empl);
        }

        
        public async Task<IActionResult> Delete(Guid Id)
        {
            var emp = await _dbContext.Employees.FindAsync(Id);
            if(emp != null)
            {
                _dbContext.Employees.Remove(emp);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            TempData["error"] = "Unable to Delete Employee Details";
            return View();

        }
    }
}
