using AutoMapper;
using Microsoft.AspNetCore.Http;
using MyApp.Entity;

namespace Mapping.Section.LoginMapping
{
    public class LoginMap : Profile
    {
        public LoginMap() {

            CreateMap<IFormCollection, EntityLogin>() 
                    .ForMember(d => d.EMAIL, s => s.MapFrom(fm => fm["txt_EMAIL"]))
                    .ForMember(d => d.PASSWORD, s => s.MapFrom(fm => fm["txt_PASSWORD"]));
 
        }
 
         
    }
}
