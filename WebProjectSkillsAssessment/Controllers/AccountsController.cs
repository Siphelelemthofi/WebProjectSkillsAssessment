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
            if(Code == 0)
            {
              return NotFound();
            }
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
            if (ModelState.IsValid)
            {
                bool CheckIfAccountNumberExist = _accountRepository.CheckAccountNumber(account.AccountNumber);
                if (CheckIfAccountNumberExist)
                {
                    ViewBag.CheckAccountNumber = " Account Number " + account.AccountNumber + " already exist in our system";
                    return View();
                }
                  _accountRepository.AddNewAccount(account);
                  return RedirectToAction("GetAccountList", "Accounts", new { Code = account.Code });
            }
            return View(account);
        }
        [HttpGet]
        public ActionResult UpdateAccountInformation(string AccountNumber)
        {
            var getAccountDetails = _accountRepository.GetAccountDetails(AccountNumber);
            return View(getAccountDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAccountInformation(Account account)
        {   
            if (ModelState.IsValid)
            {
                _accountRepository.UpdateAccountInformation(account);
                return RedirectToAction("GetAccountList", "Accounts", new { Code = account.Code });
            }           
            return View(account);
        }
    }
}

