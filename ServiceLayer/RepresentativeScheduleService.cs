using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepSchedule
{
    public class RepresentativeScheduleService : IRepresentativeScheduleService
    {
        public async Task<List<RepresentativeSchedule>> GetSchedules(DateTime scheduleStartDate)
        {
            RepresentativeScheduleRepo rsObject = new RepresentativeScheduleRepo();
            return await rsObject.GetAllSchedules(scheduleStartDate);
        }
    }
}
