using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MedicalRepSchedule
{
    public class RepresentativeScheduleRepo : IRepresentativeScheduleRepo
    {
        RepresentativeScheduleContext dbContext = new RepresentativeScheduleContext();
        public async Task<List<RepresentativeSchedule>> GetAllSchedules(DateTime scheduleStartDate)
        {
            List<RepresentativeSchedule> schedules = new List<RepresentativeSchedule>();
            List<DoctorData> doctorDatas = await (from data in dbContext.DoctorDatas select data).ToListAsync();
            foreach (DoctorData data in doctorDatas)
            {
                RepresentativeSchedule representativeSchedule = new RepresentativeSchedule();
                representativeSchedule.DoctorName = data.DoctorName;
                representativeSchedule.DoctorContactNumber = data.DoctorContactNumber;
                representativeSchedule.DoctorId = data.DoctorId;
                representativeSchedule.TreatingAilment = data.TreatingAilment;
                schedules.Add(representativeSchedule);
            }
            schedules[0].Name = "R1";
            schedules[1].Name = "R2";
            schedules[2].Name = "R3";
            schedules[3].Name = "R1";
            schedules[4].Name = "R2";
            DateTime days = scheduleStartDate;
            DateTime endDate = scheduleStartDate;
            for (int i = 0; i < schedules.Count;)
            {
                schedules[i].MeetingSlot = "1PM to 2PM";

                if (days.DayOfWeek == DayOfWeek.Sunday)
                {
                    days = days.AddDays(1);
                }
                else
                {
                    schedules[i].DateOfMeeting = days;
                    days = days.AddDays(1);
                    i++;
                }
                endDate.AddDays(1);
            }

            List<MedicinestockTable> medStock = await GetAllStock();
            foreach (RepresentativeSchedule rs in schedules)
            {
                List<String> myMedicine = new List<string>();
                foreach (MedicinestockTable medicine in medStock)
                {
                    if (rs.TreatingAilment == medicine.TargetAilment)
                    {
                        myMedicine.Add(medicine.Name);
                    }
                }
                rs.MedicineName = string.Join(",", myMedicine.ToArray());
            }
            await dbContext.RepresentativeSchedules.AddRangeAsync(schedules);
            await dbContext.SaveChangesAsync();
            List<RepresentativeSchedule> rep = await dbContext.RepresentativeSchedules.OrderByDescending(r => r.ScheduleId).Take(5).OrderBy(r => r.ScheduleId).ToListAsync();
            return rep;
        }
        public async Task<List<MedicinestockTable>> GetAllStock()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44383/api/MedicineStock");
                List<MedicinestockTable> medicineStocks = await client.GetFromJsonAsync<List<MedicinestockTable>>("");
                return medicineStocks;
            }
        }

    }
}
