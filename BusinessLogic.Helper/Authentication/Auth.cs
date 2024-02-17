using BusinessLogic.Helper.Interface;
using MyApp.Entity;
using System.Security.Claims;

namespace BusinessLogic.Helper.Authentication
{
    public class Auth : IAuth
    {
        public virtual bool SetAuthentication(EntityLogin entity, ref List<Claim> principal)
        {
            try
            {
                var claims = new List<Claim>() {
                                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(entity.USER_KEY)),
                                        new Claim(ClaimTypes.Name, entity.USER_NAME == null ? "admin":entity.USER_NAME),
                                        new Claim(ClaimTypes.Role, entity.USER_ROLE),
                                        new Claim(ClaimTypes.Email, entity.EMAIL== null ? "admin@gmail.com":entity.EMAIL)
                                };

                principal = claims;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }

}
