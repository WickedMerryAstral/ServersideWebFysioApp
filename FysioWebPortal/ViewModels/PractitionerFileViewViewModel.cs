using Core.Domain;
using Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioWebPortal.ViewModels
{
    public class PractitionerFileViewViewModel
    {
        public Patient patient { get; set; }
        public TreatmentPlan treatmentPlan { get; set; }
        public List<Appointment> patientAppointments { get; set; }
        public List<Comment> patientComments { get; set; }
    }
}
