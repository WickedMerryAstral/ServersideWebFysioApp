using Microsoft.AspNetCore.Mvc;
using FysioWebPortal.ViewModels;
using System;
using Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FysioWebPortal.Controllers
{
    public class PractitionerController : Controller
    {
        private IPatientRepository patientRepo;
        private IAppointmentRepository appRepo;
        private ICommentRepository commentRepo;
        private IPractitionerRepo practRepo;
        private ITreatmentPlanRepository trePlanRepo;
        private IFileRepository fileRepo;

        public PractitionerController(IPatientRepository patient,
            IAppointmentRepository appointment,
            ICommentRepository comment,
            IPractitionerRepo practitioner,
            ITreatmentPlanRepository treatmentplan,
            IFileRepository file) {

            this.patientRepo = patient;
            this.appRepo = appointment;
            this.commentRepo = comment;
            this.practRepo = practitioner;
            this.trePlanRepo = treatmentplan;
            this.fileRepo = file;
        }

        [HttpPost]
        public IActionResult PractitionerIntakePatient(IntakeViewModel model) {
            //Selected items from dropdowns are IDs.
            Patient p = new Patient();
            p = model.patient;
            p.patientFile = model.patient.patientFile;

            // Attaching practitioners rather than IDs.
            p.patientFile.mainPractitioner = 
                practRepo.GetPractitionerById(Convert.ToInt32(model.selectedPractitioner));
            p.patientFile.intakeBy =
                practRepo.GetPractitionerById(Convert.ToInt32(model.selectedIntaker));
            p.patientFile.intakeSupervisedBy =
                practRepo.GetPractitionerById(Convert.ToInt32(model.selectedSupervisor));

            if (model.selectedPatientType == "Student")
            {
                p.studentNumber = model.number;
                p.patientFile.studentNumber = model.number;
            }
            else if (model.selectedPatientType == "Employee")
            {
                p.employeeNumber = model.number;
                p.patientFile.employeeNumber = model.number;
            }

            // TODO: Use API
            TreatmentPlan t = new TreatmentPlan();
            t.weeklyAppointments = 3;
            t.sessionDuration = "60";

            p.patientFileId = p.patientFile.patientId;
            p.patientFile.patientId = patientRepo.AddPatient(p);
            p.patientFile.treatmentPlanId = trePlanRepo.AddTreatmentPlan(t);
            patientRepo.Save();
            
            ModelState.Clear();
            return Redirect("~/Practitioner/PractitionerDashboard");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PractitionerDashboard()
        {
            // Temporarily use Diana's ID
            Practitioner currentUser = new Practitioner();
            currentUser = practRepo.GetPractitionerById(1);

            // Gets all relevant data for signed in practictioner.
            PractitionerDashboardViewModel vm = new PractitionerDashboardViewModel();
            vm.patientlist = patientRepo.GetPatientsByPractitioner(currentUser).ToList();
            List<Appointment> appointments = appRepo.GetAppointmentsByPractitioner(currentUser).ToList();
            vm.todaysAppointments = new List<Appointment>();
            foreach (Appointment a in appointments)
            {
                if (a.startTime.Date == DateTime.Now.Date)
                {
                    vm.todaysAppointments.Add(a);
                }
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult PractitionerIntakePatient()
        {
            // ViewModel for view-specific model requirements.
            var vm = new IntakeViewModel();

            // Getting data from repositories.
            List<Practitioner> practitioners = practRepo.GetPractitioners().ToList();

            // Populating drop down lists
            List<SelectListItem> prac = new List<SelectListItem>();
            foreach (Practitioner p in practitioners)
            {
                prac.Add(new SelectListItem(p.name, p.practitionerId.ToString()));
            }
            vm.practitionersItems = prac;


            List<SelectListItem> sup = new List<SelectListItem>();
            foreach (Practitioner p in practitioners)
            {
                // Only teachers can supervise.
                if (p.type == "Teacher") {
                    sup.Add(new SelectListItem(p.name, p.practitionerId.ToString()));
                }
            }
            vm.supervisorItems = sup;

            List<SelectListItem> intake = new List<SelectListItem>();
            foreach (Practitioner p in practitioners)
            {
                intake.Add(new SelectListItem(p.name, p.practitionerId.ToString()));
            }
            vm.intakerItems = intake;

            List<SelectListItem> patientTypes = new List<SelectListItem>();
            patientTypes.Add(new SelectListItem("Student", "Student"));
            patientTypes.Add(new SelectListItem("Employee", "Employee"));
            vm.patientTypeItems = patientTypes;

            return View(vm);
        }

        [HttpGet]
        public IActionResult PractitionerPatientFile(Patient p) {
            PractitionerFileViewViewModel vm = new PractitionerFileViewViewModel();
            vm.patient = p;
            vm.patient.patientFile = fileRepo.GetFileByPatient(p);

            // Appointments.
            vm.patientAppointments = appRepo.GetAppointmentsByPatient(p).ToList();
            if (vm.patientAppointments == null) {
                vm.patientAppointments = new List<Appointment>();
            }

            // Patient file comments, all are visible for practitioners.
            vm.patientComments = commentRepo.GetCommentsByPatient(p).ToList();
            if (vm.patientComments == null) { 
                vm.patientComments = new List<Comment>();
            }

            // Treatment plan.
            vm.treatmentPlan = trePlanRepo.GetTreatmentPlanById(p.patientFile.treatmentPlanId);
            if (vm.treatmentPlan == null) {
                vm.treatmentPlan = new TreatmentPlan();
            }

            // Keeping track of the current patient.
            TempData["CurrentPatient"] = JsonConvert.SerializeObject(p);

            return View(vm);
        }

        [HttpGet]
        public IActionResult PractitionerCreateAppointment()
        {
            Appointment app = new Appointment();
            return View(app);
        }

        [HttpPost]
        public IActionResult PractitionerCreateAppointment(Appointment a) {
            Patient p = JsonConvert
                .DeserializeObject<Patient>(TempData["CurrentPatient"].ToString());

            a.patient = p;
            appRepo.AddAppointment(a);
            return View("PractitionerFileView", a.patient);
        }

        [HttpGet]
        public IActionResult PractitionerEditAppointment(Appointment a) {
            return View(a);
        }
    }
}
