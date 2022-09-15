using Microsoft.AspNetCore.Mvc;
using WebProjectSkillsAssessment.Bussiness.Interface;

namespace WebProjectSkillsAssessment.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransationRepository  _transationRepository;
        public TransactionsController(ITransationRepository  transationRepository)
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
    }
}
