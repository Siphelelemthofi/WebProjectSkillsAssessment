using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;
using WebProjectSkillsAssessment.Domain.Manager;
using WebProjectSkillsAssessment.ViewModel.PersonViewModel;

namespace WebProjectSkillsAssessment.Controllers
{
    public class PersonsController : Controller
    {
      
        private readonly IPersonRepository _personRepository;
        public PersonsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            var isUserValid = _personRepository.isUserValidToLogin(userLogin);
            if (ModelState.IsValid)
            {
               if(isUserValid)
                {
                    return Redirect("GetListOfPersons");
                }
                else
                {
                    ViewBag.IsValidMessage = "Incorrect Details please try again";
                    return View();
                }
            }
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
        public ActionResult DeletePerson(int IdORCode)
        {
             _personRepository.DeleteUserWithNoAccountOrAccountClosed(IdORCode);
            return View();
        }
        [HttpGet]
        public ActionResult UpdateUserInformation(int IdORCode)
        {
            var GetPersonDetailsByIdOrCode = _personRepository.GetPersonByCodeOrId(IdORCode);
            return View(GetPersonDetailsByIdOrCode);
        }
        [HttpPost]
        public ActionResult UpdateUserInformation(Person Person)
        {
            if (ModelState.IsValid)
            {
                _personRepository.UpdatePersonInformation(Person);
            }
            return Redirect("GetListOfPersons");
        }
    }
}
