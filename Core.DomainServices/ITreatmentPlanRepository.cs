using System;
using Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface ITreatmentPlanRepository
    {
        TreatmentPlan GetTreatmentPlanByPatient(PatientFile p);
        TreatmentPlan GetTreatmentPlanById(int id);
        int AddTreatmentPlan(TreatmentPlan t);
    }
}
