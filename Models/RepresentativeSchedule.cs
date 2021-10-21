using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepSchedule
{
    [Table("RepresentativeSchedule")]
    public class RepresentativeSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; set; }
        public string Name { get; set; }
        [ForeignKey("DoctorData")]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string MeetingSlot { get; set; }
        public DateTime DateOfMeeting { get; set; }
        public string DoctorContactNumber { get; set; }
        public string MedicineName { get; set; }
        public string TreatingAilment { get; set; }
    }
}
