using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Pages.Customer.Order
{
    public class DeleteModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly ICar carRep;

        public DeleteModel(IOrder orderRep, ICar carRep)
        {
            this.orderRep = orderRep;
            this.carRep = carRep;
        }

        [BindProperty]
        public Data.Order Order { get; set; } = default!;
        public Car Car { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Order = orderRep.GetById(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Order = orderRep.GetById(id);
            Car = carRep.GetById(Order.Car.Id);
            Car.Available = true;
            carRep.Update(Car);
            orderRep.Delete(Order);
            return RedirectToPage("./Index");
        }
    }
}
