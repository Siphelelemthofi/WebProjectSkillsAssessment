using ManagePeopleWithTheirAccounts.Business.PersonBusiness;
using ManagePeopleWithTheirAccounts.ViewModel.PersonViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;


namespace WebProjectSkillsAssessment.Controllers
{
    public class PersonsController : Controller
    {

        private readonly IPersonRepository _personRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly PersonBusiness _personBusiness;
        public PersonsController(IPersonRepository personRepository,PersonBusiness  personBusiness, IAccountRepository accountRepository)
        {
            _personRepository = personRepository;
            _personBusiness = personBusiness;
            _accountRepository = accountRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetListOfPersons(int? PageNumber, string SearchString)
        {
            int pageSize = 10;
            var getListOfPeople = _personBusiness.GetListOfPerson(SearchString);
            return View(PaginationList<GetAllPersonsViewModel>.Create(getListOfPeople,
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
        public ActionResult AddNewPerson(AddNewPersonViewModel  addNewPersonViewModel)
        {
            if (ModelState.IsValid)
            { 
                bool  CheckIfIdNumberExist = _personRepository.CheckIfIdNumberExist(addNewPersonViewModel.Id_number);
                if (CheckIfIdNumberExist)
                {
                    ViewBag.DuplicateIDNumber = " Id_Number " + addNewPersonViewModel.Id_number + " already exists in our system ";
                    return View();
                }
                    _personBusiness.AddNewPerson(addNewPersonViewModel);
                    return Redirect("GetListOfPersons");
              }
            return View(addNewPersonViewModel);
        }
        [HttpGet]
        public ActionResult GetPersonDetailsByIdOrCode(int IdORCode)
        {
            PersonDetailsWithListOfAccountViewModel persoDetailWithAccounts = new PersonDetailsWithListOfAccountViewModel();
            persoDetailWithAccounts.GetPersonDetails = _personBusiness.GetPersonDetailsByIdOrCode(IdORCode);
            persoDetailWithAccounts.AccountList = _accountRepository.GetPersonAccountByCodeOrId(IdORCode);
            return View(persoDetailWithAccounts);
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
            var GetPersonDetailsByIdOrCode = _personBusiness.GetInformationToUpdate(IdORCode);
            return View(GetPersonDetailsByIdOrCode);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserInformation(UpdatePersonInformationViewModel  updatePersonInformationViewModel)
        {
            if (ModelState.IsValid)
            {
                _personBusiness.UpdatePersonInformation(updatePersonInformationViewModel);
                return Redirect("GetListOfPersons");
            }
            return View(updatePersonInformationViewModel);
        }
    }
}
