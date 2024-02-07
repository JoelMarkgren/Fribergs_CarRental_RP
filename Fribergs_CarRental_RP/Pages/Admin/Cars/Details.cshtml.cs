using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Pages.Admin.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ICar carRep;

        public DetailsModel(ICar carRep)
        {
            this.carRep = carRep;
        }

        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Car = carRep.GetById(id);


            return Page();
        }
    }
}
