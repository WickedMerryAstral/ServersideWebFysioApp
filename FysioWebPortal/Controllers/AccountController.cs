using Microsoft.AspNetCore.Mvc;
using FysioWebPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioWebPortal.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register() {
            RegisterViewModel vm = new RegisterViewModel();
            
            // Teachers and students are both practitioners respectively.
            vm.accountTypeOptions.Add("Teacher");
            vm.accountTypeOptions.Add("Student");
            vm.accountTypeOptions.Add("Patient");
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel vm)
        {
            // Insert Account into Identity repository
            return View();
        }
    }
}
