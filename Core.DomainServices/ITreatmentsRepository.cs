﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITreatmentsRepository
    {
        IEnumerable<Treatment> GetTreatments();
    }
}
