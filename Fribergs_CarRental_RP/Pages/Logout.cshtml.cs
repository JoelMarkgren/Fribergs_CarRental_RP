using Fribergs_CarRental_RP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fribergs_CarRental_RP.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public LogoutModel(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public IActionResult OnGet()
        {          
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("AdminLoggedIn")))
            {               
                httpContextAccessor.HttpContext.Session.Remove("AdminLoggedIn");
                return RedirectToPage("/Index");
            }
            else if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerLoggedIn")))
            {          
                httpContextAccessor.HttpContext.Session.Remove("CustomerLoggedIn");
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}
