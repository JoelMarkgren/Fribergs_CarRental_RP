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

namespace Fribergs_CarRental_RP.Pages.Admin.Customer
{
    public class EditModel : PageModel
    {
        private readonly ICustomer customerRep;

        public EditModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        [BindProperty]
        public Data.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = customerRep.GetById(id);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Customer = customerRep.Update(Customer);
            return RedirectToPage("./Index");
        }
    }
}
