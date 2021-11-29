using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface IAppointmentCode
    {
        IEnumerable<string> GetCodes();
        Task GetDetailsByCode(string s);
    }
}
