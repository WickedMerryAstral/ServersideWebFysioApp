using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.EF.Fysio
{
    public class EFAppointmentRepository : IAppointmentRepository
    {
        private FysioDBContext context;

        public EFAppointmentRepository(FysioDBContext db)
        {
            this.context = db;
        }

        public int AddAppointment(Appointment a)
        {
            context.appointments.Add(a);
            context.SaveChanges();
            return a.appointmentId;
        }

        public void DeleteAppointment(Appointment a)
        {
            Appointment temp = context.appointments.Where(app =>
            app.appointmentId == a.appointmentId).First();
            context.Remove(temp);
            context.SaveChanges();
        }

        public Appointment GetAppointmentByNumber(int i)
        {
            Appointment temp = context.appointments.Where(app =>
            app.appointmentId == i).First();
            return temp;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return context.appointments;
        }

        public IEnumerable<Appointment> GetAppointmentsByPatient(Patient p)
        {
            return context.appointments.Where(app => app.patient.patientId == p.patientId);
        }

        public IEnumerable<Appointment> GetAppointmentsByPractitioner(Practitioner p)
        {
            return context.appointments.Where(app =>
            app.practitioner.practitionerId == p.practitionerId);
        }

        public void UpdateAppointment(Appointment a)
        {
            Appointment temp = context.appointments.Where(app =>
            app.appointmentId == a.appointmentId).First();

            temp.details = a.details;
            temp.endTime = a.endTime;
            temp.treatment = a.treatment;
            temp.startTime = a.startTime;
            temp.specialties = a.specialties;
            temp.patient = a.patient;
            temp.location = a.location;
            temp.practitioner = a.practitioner;

            context.appointments.Update(temp);
            context.SaveChanges();
        }
    }
}
