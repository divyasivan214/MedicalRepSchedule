using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepSchedule.Models
{
    public class MedicinestockTableException : Exception
    {
        public MedicinestockTableException(string errMsg) : base(errMsg)
        {

        }

        public MedicinestockTableException() : base()
        {
        }

        public MedicinestockTableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
