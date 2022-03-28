using AppointmentScheduling.Models.ViewModels;
using AppointmentScheduling.Services;
using AppointmentScheduling.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace AppointmentScheduling.Controllers.Api
{
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentApiController : Controller
    {
        private readonly IAppointmentServices _appointmentServices;
        private readonly IHttpContextAccessor _httpcontextAccessor;
        private readonly string loginUserId;
        private readonly string role;
        public AppointmentApiController(IAppointmentServices appointmentServices,IHttpContextAccessor httpcontextAccessor)
        {
            _appointmentServices = appointmentServices;
            _httpcontextAccessor = httpcontextAccessor;
            loginUserId = _httpcontextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpcontextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }
        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(AppointmentVM data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _appointmentServices.AddUpdate(data).Result;
                if(commonResponse.Status==1)
                {
                    commonResponse.Message = Helper.AppointmentUpdated;
                }
                if (commonResponse.Status == 2)
                {
                    commonResponse.Message = Helper.AppointmentAdded;
                }
            }
            catch (Exception e)
            {
                commonResponse.Message = e.Message;
                commonResponse.Status = Helper.failure_code;
            }
            return Ok(commonResponse);
        }
    }
}
