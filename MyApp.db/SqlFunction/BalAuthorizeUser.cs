
using MyApp.db.Interfaces;
using MyApp.db.MydbContext;
using MyApp.Entity;
using System.Data;

namespace MyApp.db.SqlFunctions
{
    public class BalAuthorizeUser : IBalAuthorizeUser
    {
        private readonly AppdbContext _context;

        public BalAuthorizeUser(AppdbContext context)
        {
            _context = context;
        }


        public EntityLogin GetAuthorizeUser(string Email, string Password)
        {

            try
            {
                return _context.AuthorizeUsers.Where(x => x.EMAIL == Email && x.PASSWORD == Password).FirstOrDefault();

            }
            catch (Exception ex)
            { 
                return null;
            }

        }

    }
}
