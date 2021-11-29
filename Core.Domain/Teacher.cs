using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Teacher : Practitioner
    {
        public string phone { get; set; }
        public string employeeNumber { get; set; }
        public string BIGNumber { get; set; }
    }
}
