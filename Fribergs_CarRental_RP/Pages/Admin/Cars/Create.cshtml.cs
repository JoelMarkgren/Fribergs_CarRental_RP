using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Pages.Admin.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ICar carRep;

        public CreateModel(ICar carRep)
        {
            this.carRep = carRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Car.Available = true;
            carRep.Add(Car);
            return RedirectToPage("./Index");
        }
    }
}
