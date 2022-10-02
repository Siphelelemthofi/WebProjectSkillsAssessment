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
        public ActionResult Index() 
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetTransactionsListByIdOrCode(int AccountCode)
        {
            var getTransactionList = _transationRepository.GetTransactionsByAccountCodeOrId(AccountCode);
            return View(getTransactionList);
        }
        public ActionResult AddTransactions()
        {
            return View();
        }
        public ActionResult GetTransactionDetailsByAccountCodeOrId(int AccountCode)
        {
            var getTransactionList = _transationRepository.GetTransactionDetailsCodeOrId(AccountCode);
            return View(getTransactionList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTransactions(Transaction transaction)
        {
            
            if (ModelState.IsValid)
            {
                decimal CheckBalance = _accountRepository.GetCurrentAccountBalance(transaction.Code);
                if (transaction.TransactionDate > DateTime.Now)
                {
                    ViewBag.isDateFuterDate = "The transaction date can never be in the future";
                    return View();  
                }
               if(transaction.Amount < 1)
                 {
                    ViewBag.CheckAmount = "The transaction amount can never be zero";
                    return View();
                 }
               if (transaction.Description.Equals("Debit"))
                {
                    if (transaction.Amount > CheckBalance)
                    {
                        ViewBag.Balance = "you cannot do Debit Transaction with amount More than current balance";
                        return View();
                    }
                }
                 _transationRepository.AddNewTransaction(transaction);
                return RedirectToAction("GetTransactionsListByIdOrCode", "Transactions", new { AccountCode = transaction.Code });
            }
            return View(transaction);   
           
        }
        [HttpGet]
        public IActionResult UpdateTransactions(int Code)
        {
            var getTransactionList = _transationRepository.GetTransactionDetailsCodeOrId(Code);
            return View(getTransactionList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTransactions(Transaction transaction)
        {
            
            if(ModelState.IsValid)
            {
                decimal CheckAccountBalance = _accountRepository.GetCurrentAccountBalance(transaction.Code);
                if (transaction.Description.Equals("Debit"))
                {
                    if (transaction.Amount > CheckAccountBalance)
                    {
                        ViewBag.Balance = "you cannot do Debit Transaction with amount More than current balance";
                        return View(transaction);
                    }
                }
                    _transationRepository.UpdateTransactionInformation(transaction);
                    return RedirectToAction("GetTransactionsListByIdOrCode", "Transactions", new { AccountCode = transaction.AccountCode });
              }
            return View(transaction);   
            
        }
    }
}
