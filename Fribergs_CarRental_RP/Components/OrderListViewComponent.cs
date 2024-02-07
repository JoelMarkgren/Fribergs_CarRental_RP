using Fribergs_CarRental_RP.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fribergs_CarRental_RP.Components
{
    public class OrderListViewComponent : ViewComponent
    {
        private readonly IOrder orderRep;

        public OrderListViewComponent(IOrder orderRep)
        {
            this.orderRep = orderRep;
        }

        public IViewComponentResult Invoke(int count)
        {
            var orders = orderRep.GetAll();
            if (count > 0)
            {
                return View(orders.OrderByDescending(o => o.Id).Take(count).ToList());
            }
            return View(orders);
        }

    }
}
