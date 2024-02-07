using System.ComponentModel.DataAnnotations;

namespace Fribergs_CarRental_RP.Data
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        

        public User(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
            
        }
        public User()
        {

        }
    }
}
