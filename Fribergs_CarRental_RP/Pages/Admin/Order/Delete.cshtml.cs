using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Pages.Admin.Order
{
    public class DeleteModel : PageModel
    {
        private readonly IOrder orderRep;

        public DeleteModel(IOrder orderRep)
        {
            this.orderRep = orderRep;
        }

        [BindProperty]
        public Data.Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {

            Order = orderRep.GetById(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Order = orderRep.GetById(id);
            orderRep.Delete(Order);
            return RedirectToPage("./Index");
        }
    }
}
