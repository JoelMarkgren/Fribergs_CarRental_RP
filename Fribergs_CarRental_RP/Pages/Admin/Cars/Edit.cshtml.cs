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

namespace Fribergs_CarRental_RP.Pages.Admin.Cars
{
    public class EditModel : PageModel
    {
        private readonly ICar carRep;

        public EditModel(ICar carRep)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var updatedCar = carRep.Update(Car);
            return RedirectToPage("./Index");
        }
    }
}
