using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;
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
        [HttpGet]
        public ActionResult GetPersonDetailsByIdOrCode(int IdORCode)
        {
            var GetPersonDetailsByIdOrCode =_personRepository.GetPersonByCodeOrId(IdORCode);
            return View(GetPersonDetailsByIdOrCode);
        }
    }
}
