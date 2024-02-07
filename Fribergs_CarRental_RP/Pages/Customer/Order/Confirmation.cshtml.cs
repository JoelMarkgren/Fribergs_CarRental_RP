using Fribergs_CarRental_RP.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fribergs_CarRental_RP.Pages.Customer.Order
{
    public class ConfirmationModel : PageModel
    {
        private readonly IOrder orderRep;

        public ConfirmationModel(IOrder orderRep)
        {
            this.orderRep = orderRep;
        }
        [BindProperty]
        public Data.Order Order { get; set; }
        public IActionResult OnGet(int id)
        {
            
            Order = orderRep.GetById(id);

            return Page();
        }
    }
}
