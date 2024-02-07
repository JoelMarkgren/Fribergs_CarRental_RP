using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fribergs_CarRental_RP.Data
{
    
    public class Customer : User
    {        
        public Customer(int id, string email, string password) : base(id, email, password)
        {

        }
        public Customer()
        {
            
        }
    }
}
