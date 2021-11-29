using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Patient
    {
        public List<Appointment> appointments { get; set; }
        public int patientId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public byte[] photo { get; set; }
        public DateTime birthDate { get; set; }
        public string sex { get; set; }
        public int patientFileId { get; set; }
        public PatientFile patientFile { get; set; }
#nullable enable
        public string? studentNumber { get; set; }
        public string? employeeNumber { get; set; }
#nullable disable
    }
}
