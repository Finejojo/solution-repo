using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
            ViewData["info"] = "More Information coming from the PageModel";
        }
    }
}
