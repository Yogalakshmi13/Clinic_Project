using ClinicProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClinicProject.DAL;

namespace ClinicProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Validate(LoginDetails log)
        {
            if (ModelState.IsValid)
            {
                ClinicDAL obj1 = new ClinicDAL();
                int result = obj1.LogCon(log);
                if (result == 1)
                {
                    return RedirectToAction("Home");
                }
                else
                {
                    return Content("Please enter your valid User and Password!!!");
                }
            }
            return View("Index");

        }

        
        public IActionResult Home()
        {
            return View();
        }



       
        public IActionResult AddDoctor()
        {
            return View();
        }

        public IActionResult Doctors(Doctor doc)
        {
            ClinicDAL obj = new ClinicDAL();
            int result = obj.DoctorDetail(doc);
            if (result == 1)
                return RedirectToAction("Home");
            else
                return View("AddDoctor");
        }


        
        public IActionResult AddPatient()
        {
            return View();
        }

        public IActionResult Patient(Patients pat)
        {
            ClinicDAL obj = new ClinicDAL();
            int result = obj.PatientDetail(pat);
            if (result == 1)
                return RedirectToAction("Home");
            else
                return View("AddPatient");
        }



        public IActionResult AddSchedule()
        {
            return View();
        }

        public IActionResult Schedule(Schedules sch)
        {
            ClinicDAL obj = new ClinicDAL();
            int result = obj.ScheduleDetail(sch);
            if (result == 1)
                return RedirectToAction("Home");
            else
                return View("AddSchedule");
        }

        
        
        public IActionResult ScheduleAppointment()
        {
            ClinicDAL obj = new ClinicDAL();
            List<Schedules> Listschedule = new List<Schedules>();
            Listschedule = obj.ScheduleView();
            return View(Listschedule);
        }


        
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult CancelView()
        {
            ClinicDAL obj = new ClinicDAL();
            List<Schedules> Listcancel = new List<Schedules>();
            Listcancel = obj.Cancellation();
            return View(Listcancel);
        }


        public IActionResult CancelAppointment(Schedules cad)
        {

            int result;
            int PatientId = cad.PatientId;
            if (ModelState.IsValid)
            {
                ClinicDAL obj = new ClinicDAL();
                result = obj.CancelDetails(cad);
                return RedirectToAction("Home");
            }
            else
            {
                return RedirectToAction("CancelAppointment");
            }
        }
        
        public IActionResult DoctorView(Doctor docc)
        {
            ClinicDAL obj = new ClinicDAL();
            List<Doctor> Listdoctor = new List<Doctor>();
            Listdoctor = obj.DoctorAppoint();
            return View(Listdoctor);
        }

        public IActionResult PatientView(Patients pat)
        {
            ClinicDAL obj = new ClinicDAL();
            List<Patients> Listpatient = new List<Patients>();
            Listpatient = obj.PatientAppoint();
            return View(Listpatient);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
