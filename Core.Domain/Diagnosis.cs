using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Diagnosis
    {
        public int diagnosisId { get; set; }
        public string diagnosisCode { get; set; }
        public string bodyLocation { get; set; }
        public string pathology { get; set; }
    }
}
