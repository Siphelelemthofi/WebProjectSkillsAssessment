using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;

namespace WebProjectSkillsAssessment.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountsController(IAccountRepository  accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetAccountList(int Code)
        {
            var getListOfAccount = _accountRepository.GetPersonAccountByCodeOrId(Code);
            return View(getListOfAccount);
        }
        public ActionResult GetAccountDetailsByAccountNumber(string AccountNumber)
        {
            var getAccountDetails = _accountRepository.GetAccountDetails(AccountNumber);
            return View(getAccountDetails);
        }
    }
}
