using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
	public interface IPatientRepository
	{
		IEnumerable<Patient> GetPatients();
		IEnumerable<Patient> GetPatientsByPractitioner(Practitioner p);
		Patient GetPatientByNumber(int i);
		void UpdatePatient(Patient p);
		int AddPatient(Patient p);
		void RemovePatient(Patient p);
		void Save();
	}
}
