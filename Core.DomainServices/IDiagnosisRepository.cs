using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IDiagnosisRepository
    {
        IEnumerable<Diagnosis> GetDiagnosis();
    }
}
