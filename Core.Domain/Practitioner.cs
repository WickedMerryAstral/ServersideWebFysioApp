using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Practitioner
    {
        public int practitionerId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public ICollection<Appointment> appointments { get; set; }
    }
}
