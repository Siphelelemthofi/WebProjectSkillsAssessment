using Microsoft.AspNetCore.Mvc;

namespace WebProjectSkillsAssessment.Controllers
{
    public class PersonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> GetListOfPersons()
        {
            return View();
        }
    }
}
