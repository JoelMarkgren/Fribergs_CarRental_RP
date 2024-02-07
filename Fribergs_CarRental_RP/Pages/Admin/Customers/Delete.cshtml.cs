using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Pages.Admin.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomer customerRep;

        public DeleteModel(ICustomer customerRep)
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

        public async Task<IActionResult> OnPostAsync()
        {
            customerRep.Delete(Customer);
            return RedirectToPage("./Index");
        }
    }
}
