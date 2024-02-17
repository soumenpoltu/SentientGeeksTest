using MyApp.Entity.basemodel;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Entity.models
{
    public class EntityEmployee : basemodels
    {
        [Key]
        public Int32 MAST_EMPLOYEE_KEY { get; set; }
        public string FULLNAME { get; set; }
        public string EMAIL { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE { get; set; }
    }


}
