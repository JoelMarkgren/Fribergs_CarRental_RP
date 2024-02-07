using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_CarRental_RP.Repos
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public Order Add(Order order)
        {
            applicationDbContext.Orders.Add(order);
            applicationDbContext.Entry(order.Customer).State = EntityState.Unchanged;
            applicationDbContext.Entry(order.Car).State = EntityState.Unchanged;
            applicationDbContext.SaveChanges();
            return order;
        }
        
        public bool Delete(int id)
        {
            var order = new Order() { Id = id };
            applicationDbContext.Remove(order);
            return applicationDbContext.SaveChanges() > 0;
        }

        public IEnumerable<Order> GetAll()
        {
            return applicationDbContext.Orders.Include(o=>o.Customer).Include(o=>o.Car).OrderByDescending(o=>o.Id);
        }

        public Order GetById(int id)
        {
            return applicationDbContext.Orders.Include(o =>o.Customer).Include(o =>o.Car).Where(o=>o.Id == id).FirstOrDefault();
        }

        public Order Update(Order order)
        {
            applicationDbContext.Update(order);
            applicationDbContext.SaveChanges();
            return order;
        }
    }
}
