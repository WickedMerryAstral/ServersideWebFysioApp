using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public bool isTreatment { get; set; }

        // Types of appointments are treatment codes from the Vektis database.
        // Only if it's a treatment.
        public int treatmentId { get; set; }
        public Treatment treatment { get; set; }
        public string details { get; set; }
        public string location { get; set; }

        // Special appointment notes.
        public string specialties { get; set; }
        public Patient patient { get; set; }

        // Practictioner can be either a student or teacher. In the case of it being a student
        // supervision is mandatory.
        public Practitioner practitioner { get; set; }

        // During creation, user will be prompted for a duration time, this will be used
        // to calculate the end time.
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
