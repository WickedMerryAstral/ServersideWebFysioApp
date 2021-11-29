using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.EF.Fysio
{
    public class EFFileRepository : IFileRepository
    {
        private FysioDBContext context;
        public EFFileRepository(FysioDBContext db)
        {
            this.context = db;
        }

        public PatientFile GetFileByPatient(Patient p)
        {
            return context.patientFiles.Where(pf =>
            pf.patientId == p.patientId).First();
        }

        public void UpdatePatientFile(PatientFile pf)
        {
            PatientFile temp = context.patientFiles
                .Where(file => file.fileId == pf.fileId)
                .First();
            context.patientFiles.Update(temp);
            context.SaveChanges();
        }
    }
}
