using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Comment
    {
        public int patientFileId { get; set; }
        public PatientFile patientFile { get; set; }
        public int commentId { get; set; }
        public DateTime date { get; set; }
        public Practitioner practitioner { get; set; }
        public String content { get; set; }
        public Patient patient { get; set; }
        public bool visibleForPatient { get; set; }
    }
}
