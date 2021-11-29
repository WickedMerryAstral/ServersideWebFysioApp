using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Fysio
{
    public class EFTreatmentPlanRepository : ITreatmentPlanRepository
    {
        private FysioDBContext context;
        public EFTreatmentPlanRepository(FysioDBContext db) {
            this.context = db;
        }
        public TreatmentPlan GetTreatmentPlanByPatient(PatientFile p)
        {
            TreatmentPlan temp = context.treatmentPlans
                .Where(tre => tre.treatmentPlanId == p.treatmentPlan.treatmentPlanId)
                .First();

            return temp;
        }

        public int AddTreatmentPlan(TreatmentPlan t) {
            context.treatmentPlans.Add(t);
            context.SaveChanges();
            return t.treatmentPlanId;
        }

        public TreatmentPlan GetTreatmentPlanById(int id)
        {
            TreatmentPlan temp = context.treatmentPlans
                .Where(tre => tre.treatmentPlanId == id)
                .First();

            return temp;
        }
    }
}
