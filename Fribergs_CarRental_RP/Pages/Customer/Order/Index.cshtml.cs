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
    public class IndexModel : PageModel
    {
        private readonly IOrder orderRep;

        public IndexModel(IOrder orderRep)
        {
            this.orderRep = orderRep;
        }

        public IList<Data.Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var customerLogin = HttpContext.Session.GetString("CustomerLoggedIn");
            if (string.IsNullOrEmpty(customerLogin))
            {
                 RedirectToAction("../Login/Index");
            }
            Order = orderRep.GetAll().Where(o => o.Customer.Email == customerLogin).ToList();
            var futureBookings = orderRep.GetAll().Where(o => o.Customer.Email == customerLogin && o.StartDate > DateTime.Now).ToList();

            if (Order == null)
            {
                 NotFound();
            }
        }
    }
}
