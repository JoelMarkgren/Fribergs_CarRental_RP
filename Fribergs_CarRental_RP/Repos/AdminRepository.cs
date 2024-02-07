using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;

namespace Fribergs_CarRental_RP.Repos
{
    public class AdminRepository : UserRepository<Admin>, IAdmin
    {
        

        public AdminRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }
        
    }
}
