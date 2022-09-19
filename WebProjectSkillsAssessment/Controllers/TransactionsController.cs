using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransationRepository _transationRepository;
        private readonly IAccountRepository _accountRepository;
        public TransactionsController(ITransationRepository transationRepository, IAccountRepository accountRepository)
        {
            _transationRepository = transationRepository;
            _accountRepository = accountRepository; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTransactionsListByIdOrCode(int AccountCode)
        {
            var getTransactionList = _transationRepository.GetTransactionsByAccountCodeOrId(AccountCode);
            return View(getTransactionList);
        }
        public IActionResult AddTransactions()
        {
            return View();
        }
        public IActionResult GetTransactionDetailsByAccountCodeOrId(int AccountCode)
        {
            var getTransactionList = _transationRepository.GetTransactionDetailsCodeOrId(AccountCode);
            return View(getTransactionList);
        }
        [HttpPost]
        public IActionResult AddTransactions(Transaction transaction)
        {
            decimal CheckBalance = _accountRepository.GetCurrentAccountBalance(transaction.Code);
            if (ModelState.IsValid)
            {
                if(transaction.TransactionDate > DateTime.Now)
                {
                    ViewBag.isDateFuterDate = "The transaction date can never be in the future";
                    return View();  
                }
                  if(transaction.Amount == 0)
                 {
                    ViewBag.CheckAmount = "The transaction amount can never be zero ";
                    return View();
                 }
                if (transaction.Description == "Debit")
                {
                    if (transaction.Amount > CheckBalance)
                    {
                        ViewBag.Balance = "you cannot do Debit Transaction with amount More than current balance";
                        return View();
                    }
                }
                    _transationRepository.AddNewTransaction(transaction);
            }
            return RedirectToAction("GetTransactionsListByIdOrCode", "Transactions", new { AccountCode = transaction.Code });
        }
        [HttpGet]
        public IActionResult UpdateTransactions(int Code)
        {
            var getTransactionList = _transationRepository.GetTransactionDetailsCodeOrId(Code);
            return View(getTransactionList);
        }
        [HttpPost]
        public IActionResult UpdateTransactions(Transaction transaction)
        {
            decimal CheckBalance = _accountRepository.GetCurrentAccountBalance(transaction.Code);
            if(ModelState.IsValid)
            {
                if (transaction.Description == "Debit")
                {
                    if (transaction.Amount > CheckBalance)
                    {
                        ViewBag.Balance = "you cannot do Debit Transaction with amount More than current balance";
                        return View();
                    }
                }
                else
                {
                    _transationRepository.UpdateTransactionInformation(transaction);
                }
            }
            return RedirectToAction("GetTransactionsListByIdOrCode","Transactions", new { AccountCode  = transaction.AccountCode});   
        }
    }
}
