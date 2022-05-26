using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinicProject.Models
{
    public class Cancels
    {
        [Required(ErrorMessage = "Please enter patientid")]
        public int PatientId { get; set; }
    }
}
