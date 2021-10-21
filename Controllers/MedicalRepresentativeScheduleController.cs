using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MedicalRepSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicalRepresentativeScheduleController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MedicalRepresentativeScheduleController));
        private readonly IRepresentativeScheduleService irsObj;
        public MedicalRepresentativeScheduleController(IRepresentativeScheduleService repscheduleServ)
        {
            irsObj = repscheduleServ;
        }

        [HttpGet("{scheduleStartDate}")]
        public async Task<ActionResult> GetAllRepSchedule(string scheduleStartDate)
        {
            _log4net.Info("Get All Representative Schedule  is invoked");
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                DateTime startingDate = Convert.ToDateTime(scheduleStartDate);
                List<RepresentativeSchedule> schedules = await (irsObj.GetSchedules(startingDate));
                if (schedules != null)
                {
                    return Ok(schedules);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
