using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ICustomer customerRep;

        public RegisterModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Data.Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            customerRep.Add(Customer);           
            return RedirectToPage("/Login/Index");
        }
    }
}
