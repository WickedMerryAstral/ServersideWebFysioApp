using System;
using System.Collections.Generic;
using Core.Domain;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FysioWebPortal.ViewModels
{
    public class IntakeViewModel
    {
        // Patient details. PatientFile is created during the intake, as well.
        // Patient has a PatientFile.
        public Patient patient { get; set; }

        // Form details. Number can be employee or student number, depending on
        // the selection.
        public string number { get; set; }

        // Practitioner IDs
        public string selectedPractitioner { get; set; }
        public IEnumerable<SelectListItem> practitionersItems { get; set; }

        public string selectedSupervisor { get; set; }
        public IEnumerable<SelectListItem> supervisorItems { get; set; }

        public string selectedIntaker { get; set; }
        public IEnumerable<SelectListItem> intakerItems { get; set; }

        //Patient types
        public string selectedPatientType { get; set; }
        public IEnumerable<SelectListItem> patientTypeItems { get; set; }
    }
}
