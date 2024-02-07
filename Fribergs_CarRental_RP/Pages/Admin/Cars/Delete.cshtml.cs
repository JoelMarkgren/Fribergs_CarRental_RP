using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly ICar carRep;

        public DeleteModel(ICar carRep)
        {
            this.carRep = carRep;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Car = carRep.GetById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            carRep.Delete(id);
            return RedirectToPage("./Index");
        }
            
    }
}

