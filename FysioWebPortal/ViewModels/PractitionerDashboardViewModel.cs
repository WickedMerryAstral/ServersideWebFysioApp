using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;

namespace FysioWebPortal.ViewModels
{
    public class PractitionerDashboardViewModel
    {
        public List<Patient> patientlist { get; set; }
        public List<Appointment> todaysAppointments { get; set; }
    }
}
