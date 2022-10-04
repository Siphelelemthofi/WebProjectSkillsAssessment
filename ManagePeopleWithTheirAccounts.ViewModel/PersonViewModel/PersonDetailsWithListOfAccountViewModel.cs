using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace ManagePeopleWithTheirAccounts.ViewModel.PersonViewModel
{
    public class PersonDetailsWithListOfAccountViewModel
    {
        public GetPersonDetailsByCodeViewModel GetPersonDetails { get; set; }
        public List<Account>  AccountList { get; set; }  
    }
}
