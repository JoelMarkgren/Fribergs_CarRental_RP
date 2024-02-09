using Fribergs_CarRental_RP.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Fribergs_CarRental_RP.Interfaces
{
    public interface IOrder
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        Order Add(Order order);
        bool Delete(Order order);
        Order Update(Order order);


    }
}
