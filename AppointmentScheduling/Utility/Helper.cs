using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Utility
{
    public class Helper
    {
        public static string Admin = "Admin";
        public static string Doctor = "Doctor";
        public static string Petiant = "Petiant";
        public static string AppointmentAdded = "Appointment added successfully";
        public static string AppointmentUpdated = "Appointment updated successfully";
        public static string AppointmentDeleted = "Appointment deleted successfully";
        public static string AppointmentExists = "Appointment for selected date and time already exists.";
        public static string AppointmentNotExists = "Appointment not exists.";
        public static string AppointmentAddError = "Something went wrong, please try again.";
        public static string AppointmentUpdateError = "Something went wrong, please try again.";
        public static string AppointmentWentWrong = "Something went wrong, please try again.";
        public static int success_code = 1;
        public static int failure_code = 0;

        public static List<SelectListItem> rolesDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = Helper.Admin, Text = Helper.Admin },
                new SelectListItem { Value = Helper.Doctor, Text = Helper.Doctor },
                new SelectListItem { Value = Helper.Petiant, Text = Helper.Petiant }
            };
        }


        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            for(int i=1;i<=12;i++)
            {
                duration.Add(new SelectListItem {Value = minute.ToString(),Text =i+"Hr" });
                minute = minute+ 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "Hr 30 min" });
                minute = minute + 30;

            }
            return duration;
        }
    }
}
