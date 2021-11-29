using System;
using Core.Domain;
using Core.DomainServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioWebPortal.ViewModels
{
    public class PractitionerPatientFileViewModel
    {
        public Patient patient { get; set; }
        public PatientFile file { get; set; }
        public Treatment treatment { get; set; }
        public List<Appointment> appointments { get; set; }
        public List<Comment> comments { get; set; }
    }
}
