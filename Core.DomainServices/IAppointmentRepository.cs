using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
	public interface IAppointmentRepository
	{
		int AddAppointment(Appointment a);
		void UpdateAppointment(Appointment a);
		void DeleteAppointment(Appointment a);
		Appointment GetAppointmentByNumber(int i);
		IEnumerable<Appointment> GetAppointments();
		IEnumerable<Appointment> GetAppointmentsByPractitioner(Practitioner p);
		IEnumerable<Appointment> GetAppointmentsByPatient(Patient p);
	}
}
