using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.EF.Fysio
{
    public class EFPractitionerRepo : IPractitionerRepo
    {
        private FysioDBContext context;
        public EFPractitionerRepo(FysioDBContext db) {
            this.context = db;
        }

        public IEnumerable<Practitioner> GetPractitioners()
        {
            return context.practitioners;
        }

        public Practitioner GetPractitionerById(int id)
        {
            Practitioner prac = context.practitioners.Where(p => p.practitionerId == id).First();
            return prac;
        }
    }
}
