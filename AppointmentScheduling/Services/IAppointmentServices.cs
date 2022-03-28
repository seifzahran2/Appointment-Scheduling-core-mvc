using AppointmentScheduling.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Services
{
    public interface IAppointmentServices
    {
        public List<PatientVM> GetPatientList();
        public List<DoctorVM> GetDoctorList();
        public Task<int> AddUpdate(AppointmentVM model);
    }
}
