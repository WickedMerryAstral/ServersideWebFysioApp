using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class AppUser
    {
        public int appUserId { get; set; }
        public string email { get; set; }
        public string password { get; set; }

#nullable enable
        // Logged in user can be either a patient, or a practitioner. Email is always unique.
        public Patient? patient { get; set; }
        public int? patientId { get; set; }
        public Practitioner? practitioner { get; set; }
        public int? practitionerId { get; set; }
#nullable disable

    }
}
