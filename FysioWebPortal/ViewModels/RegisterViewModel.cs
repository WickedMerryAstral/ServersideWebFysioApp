using System;
using System.Collections.Generic;
using Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace FysioWebPortal.ViewModels
{
    public class RegisterViewModel
    {
        public AppUser newUser { get; set; }
        public List<string> accountTypeOptions { get; set; }

        public string chosenType { get; set; }
    }
}
