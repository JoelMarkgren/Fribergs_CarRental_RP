using Fribergs_CarRental_RP.Data;

namespace Fribergs_CarRental_RP.Interfaces
{
    public interface ICar
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();
        Car Add(Car car);
        bool Delete(int id);
        Car Update(Car car);
    }
}
