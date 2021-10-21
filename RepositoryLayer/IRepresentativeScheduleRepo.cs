using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepSchedule
{
    public interface IRepresentativeScheduleRepo
    {
        Task<List<RepresentativeSchedule>> GetAllSchedules(DateTime scheduleStartDate);
    }
}
