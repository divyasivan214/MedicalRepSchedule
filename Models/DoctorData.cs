using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepSchedule
{
    public class DoctorData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string TreatingAilment { get; set; }
        public string DoctorContactNumber { get; set; }
    }
}
