using MyApp.Entity.basemodel;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Entity
{
    public class EntityLogin : basemodels
    {
        [Key]
        public int USER_KEY { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string USER_ROLE { get; set; }


    }

}
