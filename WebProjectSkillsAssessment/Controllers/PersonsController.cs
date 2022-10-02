using ManagePeopleWithTheirAccounts.Business.PersonBusiness;
using ManagePeopleWithTheirAccounts.ViewModel.PersonViewModel;
using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;


namespace WebProjectSkillsAssessment.Controllers
{
    public class PersonsController : Controller
    {

        private readonly IPersonRepository _personRepository; 
        private readonly PersonBusiness _personBusiness;
        public PersonsController(IPersonRepository personRepository,PersonBusiness  personBusiness)
        {
            _personRepository = personRepository;
            _personBusiness = personBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetListOfPersons(int? PageNumber, string SearchString)
        {
            int pageSize = 10;
            var getListOfPeople = _personBusiness.GetListOfPerson(SearchString);
            return View(PaginationList<PersonsViewModel>.Create(getListOfPeople,
                PageNumber ?? 1, pageSize));
        }
        public ActionResult GetListOfPeopleWithNoAccount(int? PageNumber, string SearchString)
        {
            int pageSize = 10;
            var getListOfPeople = _personRepository.GetPersonListWithNoAccounts(SearchString);
            return View(PaginationList<Person>.Create(getListOfPeople,
                PageNumber ?? 1, pageSize));

        }
        public ActionResult AddNewPerson()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewPerson(AddNewPerson addNewPerson)
        {
           
            if (ModelState.IsValid)
            { 
                bool  CheckIfIdNumberExist = _personRepository.CheckIfIdNumberExist(addNewPerson.Id_number);
                if (CheckIfIdNumberExist)
                {
                    ViewBag.DuplicateIDNumber = " Id_Number " + addNewPerson.Id_number + " already exists in our system ";
                    return View();
                }
                    _personRepository.AddNewPerson(addNewPerson);
                    return Redirect("GetListOfPersons");
              }
            return View(addNewPerson);
        }
        [HttpGet]
        public ActionResult GetPersonDetailsByIdOrCode(int IdORCode)
        {
            var GetPersonDetailsByIdOrCode = _personRepository.GetPersonByCodeOrId(IdORCode);
            return View(GetPersonDetailsByIdOrCode);
        }
        public ActionResult DeletePerson(int IdORCode)
        {
            var GetPersonDetailsByIdOrCode = _personRepository.GetPersonByCodeOrId(IdORCode);
            return View(GetPersonDetailsByIdOrCode);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePersonConfirm(int IdORCode)
        {
            _personRepository.DeleteUserWithNoAccountOrAccountClosed(IdORCode);
            return Redirect("GetListOfPeopleWithNoAccount");
        }
        [HttpGet]
        public ActionResult UpdateUserInformation(int IdORCode)
        {
            var GetPersonDetailsByIdOrCode = _personRepository.GetPersonByCodeOrId(IdORCode);
            return View(GetPersonDetailsByIdOrCode);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserInformation(Person Person)
        {
            if (ModelState.IsValid)
            {
                _personRepository.UpdatePersonInformation(Person);
                return Redirect("GetListOfPersons");
            }
            return View(Person);
        }
    }
}
