using System;
using System.Collections.Generic;
using Core.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface IPractitionerRepo
    {
		IEnumerable<Practitioner> GetPractitioners();
        Practitioner GetPractitionerById(int id);
	}
}
