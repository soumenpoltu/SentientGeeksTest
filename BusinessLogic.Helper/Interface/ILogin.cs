using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Helper.Interface
{
    public interface ILogin
    {
        bool Authlogin(IFormCollection fm, ref string tokenstrings);
    }
}
