using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class CurrencyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Convert(CurrencyModel model)
        {
            return View("Index",model);
        }
    }
}
