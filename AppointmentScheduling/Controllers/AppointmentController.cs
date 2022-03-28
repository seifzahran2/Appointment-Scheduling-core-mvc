using AppointmentScheduling.Services;
using AppointmentScheduling.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentServices _AppointmentServices;
        public AppointmentController(IAppointmentServices AppointmentServices)
        {
            _AppointmentServices = AppointmentServices;
        }
        public IActionResult Index()
        {
            ViewBag.Duration = Helper.GetTimeDropDown();
            ViewBag.DoctorsList = _AppointmentServices.GetDoctorList();
            ViewBag.PatientsList = _AppointmentServices.GetPatientList();
            return View();
        }
    }
}
