using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;
using Fribergs_CarRental_RP.Repos;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_CarRental_RP.Pages.Customer.Order
{
    public class CreateModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly ICar carRep;
        private readonly ICustomer customerRep;

        public CreateModel(IOrder orderRep, ICar carRep, ICustomer customerRep)
        {
            this.orderRep = orderRep;
            this.carRep = carRep;
            this.customerRep = customerRep;
        }

        [BindProperty]
        public Data.Order Order { get; set; } = default!;
        [BindProperty]
        public Data.Customer Customer { get; set; } = default!;
        [BindProperty]
        public Car Car { get; set; } = default!;
        public IActionResult OnGet(int id)
        {
            var customerLogin = HttpContext.Session.GetString("CustomerLoggedIn");

            if (string.IsNullOrEmpty(customerLogin))
            {
                return RedirectToPage("../Login/Index");
            }
            
            Customer =  customerRep.GetAll().Where(c => c.Email == customerLogin).FirstOrDefault();

            if (Customer == null)
            {
                return RedirectToPage("../Error");
            }

            
            Car = carRep.GetById(id);
            Car.Available = false;
            carRep.Update(Car);

            if (Car == null)
            {
                return RedirectToPage("../Error");
            }

            Order = new Data.Order { Car = Car , Customer = Customer, StartDate = DateTime.Now, EndDate = DateTime.Now};
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Clear();
            if (!TryValidateModel(Order, nameof(Order)))
            {
                return Page();
            }
            

            
            orderRep.Add(Order);

            Order = orderRep.GetAll().OrderByDescending(o => o.Id).FirstOrDefault();
            
            return RedirectToPage("./Confirmation", new { id = Order.Id });
        }
    }
}