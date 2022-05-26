using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinicProject.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required(ErrorMessage ="Enter FirstName")]
        public string Doctor_FirstName { get; set; }

        [Required(ErrorMessage = "Enter LastName")]
        public string Doctor_LastName { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Visiting_Hours { get; set; }
    }


    // public  enum special
    // {
    //Dermotologist,
    // Pediatrics,
    // Orthopedics,
    // Ophthalmology
    // }
}

