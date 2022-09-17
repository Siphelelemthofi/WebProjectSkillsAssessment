using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;
using WebProjectSkillsAssessment.Domain.Manager;
using WebProjectSkillsAssessment.ViewModel.PersonViewModel;

namespace WebProjectSkillsAssessment.Controllers
{
    public class PersonsController : Controller
    {
        public string IdNumber { get; set; } = string.Empty;
        private readonly IPersonRepository _personRepository;
        private readonly ValidationsManager _validationsManager;
        public PersonsController(IPersonRepository personRepository, ValidationsManager validationsManager)
        {
            _personRepository = personRepository;
            _validationsManager = validationsManager;   
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult GetListOfPersons(int? PageNumber, string SearchString)
        {
            int pageSize = 10;
            var getListOfPeople = _personRepository.GetPersonList(SearchString);
            return View(PaginationList<Person>.Create(getListOfPeople,
                PageNumber ?? 1, pageSize));
        }
        public ActionResult AddNewPerson()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddNewPerson(AddNewPerson  addNewPerson)
        {
            var IdNumber = _personRepository.CheckIfIdNumberExist(addNewPerson.Id_number);
            if (ModelState.IsValid)
            {
                if (IdNumber)
                {
                    ViewBag.DuplicateIDNumber = " Id_Number " + addNewPerson.Id_number + " already exists in our system ";
                    return View();
                }
            else
                {
                    _personRepository.AddNewPerson(addNewPerson);
                }
            }
            return Redirect("GetListOfPersons");
        }
        [HttpGet]
        public ActionResult GetPersonDetailsByIdOrCode(int IdORCode)
        {
            var GetPersonDetailsByIdOrCode =_personRepository.GetPersonByCodeOrId(IdORCode);
            return View(GetPersonDetailsByIdOrCode);
        }
        public ActionResult DeletePerson(int Code)
        {
             _personRepository.DeleteUserWithNoAccountOrAccountClosed(Code);
            return View();
        }
    }
}
