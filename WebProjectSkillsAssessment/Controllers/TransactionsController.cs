using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransationRepository _transationRepository;
        public TransactionsController(ITransationRepository transationRepository)
        {
            _transationRepository = transationRepository;
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
            if(ModelState.IsValid)
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

                else
                {
                    _transationRepository.AddNewTransaction(transaction);
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateTransactions()
        {
            if(ModelState.IsValid)
            {

            }
            return RedirectToAction("Index");   
        }
    }
}
