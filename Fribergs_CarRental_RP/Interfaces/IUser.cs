using Fribergs_CarRental_RP.Data;

namespace Fribergs_CarRental_RP.Interfaces
{
    public interface IUser<T> where T : User
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T user);
        bool Delete(T user);
        T Update(T user);
        T GetUserLoginInfo(string email, string password);
    }
}
