using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fribergs_CarRental_RP.Components
{
    public class CarListViewComponent : ViewComponent
    {
        private readonly ICar carRep;

        public CarListViewComponent(ICar carRep)
        {
            this.carRep = carRep;
        }
        public IViewComponentResult Invoke(int count)
        {
            var cars = carRep.GetAll().ToList();
            if (count > 0)
            {
                return View(cars.OrderByDescending(c => c.Id).Take(count).ToList());
            }
            return View(cars);
        }
    }
}
