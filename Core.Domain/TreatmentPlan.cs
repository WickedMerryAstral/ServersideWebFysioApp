using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class TreatmentPlan
    {
        public int treatmentPlanId { get; set; }
        public int treatmentId { get; set; }
        public int weeklyAppointments { get; set; }
        public string sessionDuration { get; set; }
        public int diagnosisId { get; set; }
        public int patientId { get; set; }
    }
}
