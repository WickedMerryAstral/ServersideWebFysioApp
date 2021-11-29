using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.EF.Fysio
{
    public class EFPatientRepository : IPatientRepository
    {
        private FysioDBContext context;

        public EFPatientRepository(FysioDBContext db) {
            this.context = db;
        }

        public int AddPatient(Patient p)
        {
            context.patients.Add(p);
            context.SaveChanges();
            return p.patientId;
        }

        public Patient GetPatientByNumber(int i)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatients()
        {
            return context.patients;
        }

        public IEnumerable<Patient> GetPatientsByPractitioner(Practitioner p)
        {
            return context.patients.Where(patient =>
            patient.patientFile.mainPractitioner.practitionerId == p.practitionerId);
        }

        public void RemovePatient(Patient p)
        {
            // Finding the patient first. IDs are unique.
            Patient temp = context.patients.Where(patient => patient.patientId == p.patientId)
                .First();

            context.patients.Remove(temp);
            context.SaveChanges();
        }

        public void UpdatePatient(Patient p)
        {
            // Finding the patient first. IDs are unique.
            Patient temp = context.patients.Where(patient => patient.patientId == p.patientId)
                .First();
            temp.name = p.name;
            temp.email = p.email;
            temp.phone = p.phone;
            temp.photo = p.photo;
            temp.birthDate = p.birthDate;
            temp.sex = p.sex;
            temp.employeeNumber = p.employeeNumber;
            temp.studentNumber = p.studentNumber;

            context.patients.Update(temp);
            context.SaveChanges();
        }

        public void Save() {
            context.SaveChanges();
        }
    }
}
