using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;
using Microsoft.AspNetCore.Localization;


namespace Fribergs_CarRental_RP.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRep;
        private readonly IHttpContextAccessor httpContextAccessor;

        public IndexModel(ICustomer customerRep, IHttpContextAccessor httpContextAccessor)
        {
            this.customerRep = customerRep;
            this.httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public Data.Customer Customer { get; set; } = default!;
        
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var user = customerRep.GetUserLoginInfo(Customer.Email, Customer.Password);
            if (user != null)
            {
                httpContextAccessor.HttpContext.Session.SetString("CustomerLoggedIn", Customer.Email);
                return RedirectToPage("/Customer/Index");
            }
            ModelState.AddModelError(string.Empty, "Inloggningen misslyckades.");
            return Page();
        }
    }
}
