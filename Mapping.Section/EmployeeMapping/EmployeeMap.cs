using AutoMapper;
using Microsoft.AspNetCore.Http;
using MyApp.Entity.models;

namespace Mapping.Section.LoginMapping
{
    public partial class EmployeeMap : Profile
    {
        public EmployeeMap() {

            CreateMap<IFormCollection, EntityEmployee>() 
                    .ForMember(d => d.MAST_EMPLOYEE_KEY, s => s.MapFrom(fm => Convert.ToInt32(fm["hf_Id"])))
                    .ForMember(d => d.FULLNAME, s => s.MapFrom(fm => fm["txt_FullName"]))
                    .ForMember(d => d.ADDRESS, s => s.MapFrom(fm => fm["txt_Address"]))
                    .ForMember(d => d.PHONE, s => s.MapFrom(fm => fm["txt_Phone"]))
                    .ForMember(d => d.EMAIL, s => s.MapFrom(fm => fm["txt_Email"]));
             
        }
 
         
    }
}
