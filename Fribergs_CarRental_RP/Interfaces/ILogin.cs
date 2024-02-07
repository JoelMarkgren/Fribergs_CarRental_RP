using Fribergs_CarRental_RP.Data;

namespace Fribergs_CarRental_RP.Interfaces
{
    public interface ILogin
    {
        User GetUserLoginInfo(string email, string password);
    }
}
