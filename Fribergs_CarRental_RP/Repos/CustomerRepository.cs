using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Repos
{
    public class CustomerRepository : UserRepository<Customer>, ICustomer
    {
        public CustomerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
