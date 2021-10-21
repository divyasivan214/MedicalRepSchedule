using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepSchedule
{
    public interface IRepresentativeScheduleService
    {
        Task<List<RepresentativeSchedule>> GetSchedules(DateTime scheduleStartDate);
    }
}
