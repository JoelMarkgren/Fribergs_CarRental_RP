using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_CarRental_RP.Repos
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Car Add(Car car)
        {
            applicationDbContext.Cars.Add(car);
            applicationDbContext.SaveChanges();
            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(x => x.Brand);
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(c => c.Id == id);
        }
        public bool Delete(int id)
        {
            var car = new Car() { Id = id };
            applicationDbContext.Cars.Remove(car);
            return applicationDbContext.SaveChanges() > 0;
        }
        public Car Update(Car car)
        {
            applicationDbContext.Cars.Update(car);
            applicationDbContext.SaveChanges();
            return car;
        }
    }
}
