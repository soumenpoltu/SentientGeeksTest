using MyApp.Entity;

namespace MyApp.db.Interfaces
{
    public interface IBalAuthorizeUser
    {
        EntityLogin GetAuthorizeUser(string Email, string Password);
         
    }
}
