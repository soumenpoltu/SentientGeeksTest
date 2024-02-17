using AutoMapper;
using BusinessLogic.Helper.Authentication;
using BusinessLogic.Helper.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyApp.db.Interfaces;
using MyApp.Entity;
using MyHelping.Section.interfaces;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLogic.Helper.Logics
{
    public class Login : Auth, ILogin
    {

        private readonly IBalAuthorizeUser _balAuthorizeUser;
        private readonly IMapper _mapper;
        private readonly IEncryption _encryption;
        private readonly IConfiguration _configuration;

        String errMsg = String.Empty;
        public Login(IBalAuthorizeUser balAuthorizeUser, IMapper mapper, IEncryption encryption, IConfiguration configuration)
        {

            _balAuthorizeUser = balAuthorizeUser;
            _mapper = mapper;
            _encryption = encryption;
            _configuration = configuration;
        }

        public bool Authlogin(IFormCollection fm, ref string tokenstrings)
        {
            tokenstrings = "";
            try
            {

                EntityLogin El = new EntityLogin();
                El = _mapper.Map<IFormCollection, EntityLogin>(fm);
                DataTable dt = new DataTable();
                EntityLogin login = _balAuthorizeUser.GetAuthorizeUser(El.EMAIL, _encryption.Encryptdata(El.PASSWORD));
                if (login != null)
                {

                    var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:secretkey"]));
                    var signingcredential = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
                    List<Claim> claims = new List<Claim>();
                    if (base.SetAuthentication(login, ref claims))
                    {
                        var tokenoption = new JwtSecurityToken(
                            issuer: "*",
                            audience: "*",
                            claims: claims,
                            expires: DateTime.Now.AddHours(24),
                            signingCredentials: signingcredential
                            );

                        var tokenstring = new JwtSecurityTokenHandler().WriteToken(tokenoption);
                        tokenstrings = tokenstring;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;



                // ds = _balAuthorizeUser.get
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
