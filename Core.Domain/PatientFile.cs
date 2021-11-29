using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class PatientFile
    {
        public int fileId { get; set; }
        public Patient patient { get; set; }
        public Practitioner mainPractitioner { get; set; }
        public int patientId { get; set; }
        public int age { get; set; }
        public string mainComplaint { get; set; }
        public string diagnosisCode { get; set; }

        // If the practicioner is a student, the supervision field needs to be filled.
        public Practitioner intakeBy { get; set; }

        public int treatmentPlanId { get; set; }
        public TreatmentPlan treatmentPlan { get; set; }

        public ICollection<Comment> comments { get; set; }

        //public ICollection<Appointment> appointments { get; set; }

        public DateTime IntakeDate { get; set; }
        public DateTime DischargeDate { get; set; }

#nullable enable
        public Practitioner? intakeSupervisedBy { get; set; }
#nullable disable

        // Patients can be employees or students. Teachers are assumed to be employees, too.
#nullable enable
        public string? employeeNumber { get; set; }
        public string? studentNumber { get; set; }
#nullable disable
    }
}
