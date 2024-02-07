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
using Microsoft.AspNetCore.Http;

namespace Fribergs_CarRental_RP.Pages.Login
{
    public class AdminLoginModel : PageModel
    {
        private readonly IAdmin adminRep;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AdminLoginModel(IAdmin adminRep, IHttpContextAccessor httpContextAccessor)
        {
            this.adminRep = adminRep;
            this.httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public Data.Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var user = adminRep.GetUserLoginInfo(Admin.Email, Admin.Password);
            if (user != null)
            {
                httpContextAccessor.HttpContext.Session.SetString("AdminLoggedIn", $"Inloggad som {Admin.Email}");
                return RedirectToPage("/Admin/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Inloggningen misslyckades.");
            }
            
            return Page();
        }

        //private bool AdminExists(int id)
        //{
        //    return _context.Admins.Any(e => e.Id == id);
        //}
    }
}
