using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ClinicProject.Models
{
    public class LoginDetails
    {
       

        [Required(ErrorMessage ="Enter valid username")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Enter valid password")]
        public string UserPassword { get; set; }
    }
}
