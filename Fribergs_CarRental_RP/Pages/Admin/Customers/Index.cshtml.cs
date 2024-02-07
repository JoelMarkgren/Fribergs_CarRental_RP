using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Pages.Admin.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRep;

        public IndexModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        public IList<Data.Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = customerRep.GetAll().ToList();
        }
    }
}
