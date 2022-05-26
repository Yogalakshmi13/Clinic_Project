using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinicProject.Models
{
    public class Schedules
    {
        [Key]
        public int AppointmentID { get; set; }
        public int PatientId { get; set; }
        public string Specialization { get; set; }
        public string Doctor { get; set; }
        public string VisitDate { get; set; }
        public string AppointmentTime { get; set; }
    }
}
