using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountsController(IAccountRepository accountRepository)
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
        public ActionResult AddNewPersonAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewPersonAccount(Account account)
        {
            var CheckAccountNumber = _accountRepository.CheckAccountNumber(account.AccountNumber);
            if (ModelState.IsValid)
            {
                if (CheckAccountNumber)
                {
                    ViewBag.CheckAccountNumber = " Account Number " + account.AccountNumber + " already exist in our system";
                    return View();
                }
                else
                {
                    _accountRepository.AddNewAccount(account);
                }
            }
            return RedirectToAction("GetAccountList", "Accounts", new { Code = account.Code });
        }
        [HttpGet]
        public ActionResult UpdateAccountInformation(string AccountNumber)
        {
            var getAccountDetails = _accountRepository.GetAccountDetails(AccountNumber);
            return View(getAccountDetails);
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAccountInformation(Account account)
        {
            if(ModelState.IsValid)
            {
                _accountRepository.UpdateAccountInformation(account);
            }
            return RedirectToAction("GetAccountList", "Accounts", new { Code  = account.Code });
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}

