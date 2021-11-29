using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Treatment
    {
        public int treatmentId { get; set; }
        public string treatmentCode { get; set; }
        public string description { get; set; }
        public bool hasMandatoryExplanation { get; set; }
    }
}
