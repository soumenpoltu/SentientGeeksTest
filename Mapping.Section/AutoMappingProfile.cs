using AutoMapper; 
using Mapping.Section.LoginMapping; 
using MyApp.Entity;

namespace Mapping.Section
{
    public class AutoMappingProfile :Profile
    {
        public AutoMappingProfile()
        {
            LoginMap lm = new LoginMap();
            EmployeeMap ep = new EmployeeMap();
            
        }
    }
}