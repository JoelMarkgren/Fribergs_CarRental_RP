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
    public class IndexModel : PageModel
    {
        private readonly IOrder orderRep;

        public IndexModel(IOrder orderRep)
        {
            this.orderRep = orderRep;
        }

        public IList<Data.Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Order = orderRep.GetAll().ToList();
        }
    }
}
