using MyApp.Entity;
using System.Security.Claims;

namespace BusinessLogic.Helper.Interface
{
    public interface IAuth
    {
        bool SetAuthentication(EntityLogin entity, ref List<Claim> principal);
    }
}
