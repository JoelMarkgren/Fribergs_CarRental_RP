using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Fribergs_CarRental_RP.Repos
{
    public abstract class UserRepository<T> : IUser<T> where T : User
    {
        protected readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public T GetUserLoginInfo(string email, string password)
        {
            try
            {               
                var user = applicationDbContext.Users.OfType<T>().FirstOrDefault(u => u.Email == email && u.Password == password);
                return user;
            }
            catch (Exception)
            {
                return null;
            }           
        }
        public T Add(T user)
        {
            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();
            return user;
        }

        public bool Delete(T user)
        {           
            applicationDbContext.Remove(user);
            return applicationDbContext.SaveChanges() > 0;
        }

        public IEnumerable<T> GetAll()
        {
            return applicationDbContext.Users.OfType<T>().OrderBy(u => u.Email);
        }

        public T GetById(int id)
        {
            
            return applicationDbContext.Users.OfType<T>().FirstOrDefault(u => u.Id == id);
        }

        public T Update(T user)
        {
            applicationDbContext.Update(user);
            applicationDbContext.SaveChanges();
            return user;
        }
    }
}
