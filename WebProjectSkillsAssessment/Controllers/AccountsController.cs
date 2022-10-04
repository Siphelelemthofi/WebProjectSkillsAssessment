using ManagePeopleWithTheirAccounts.ViewModel.AccountViewModel;
using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransationRepository _transationRepository;
        public AccountsController(IAccountRepository accountRepository, ITransationRepository transationRepository)
        {
            _accountRepository = accountRepository;
            _transationRepository = transationRepository;   
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
            AccountDetailsWithTransationList accountDetailsWithTransationList = new AccountDetailsWithTransationList();
            accountDetailsWithTransationList.Account = _accountRepository.GetAccountDetails(AccountNumber);
            accountDetailsWithTransationList.getTransactionsByAccountCodeOrIds = _transationRepository.GetTransactionsByAccountCodeOrId(accountDetailsWithTransationList.Account.Code);
            return View(accountDetailsWithTransationList);
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

