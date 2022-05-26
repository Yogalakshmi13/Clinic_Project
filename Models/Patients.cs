using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinicProject.Models
{
    public class Patients
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Enter FirstName")]
        public string Patient_FirstName { get; set; }

        [Required(ErrorMessage = "Enter LastName")]
        public string Patient_LastName { get; set; }


        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        public int Age { get; set; }

        public string DOB { get; set; }
    }
}
