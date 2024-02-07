using System.ComponentModel.DataAnnotations.Schema;

namespace Fribergs_CarRental_RP.Data
{
    
    public class Admin : User
    {        
        public Admin(int id, string email, string password) : base(id, email, password)
        {
            
        }
        public Admin()
        {
            
        }
    }
}
