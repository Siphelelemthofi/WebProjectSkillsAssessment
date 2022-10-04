using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace ManagePeopleWithTheirAccounts.ViewModel.AccountViewModel
{
    public class AccountDetailsWithTransationList
    {
        public Account Account { get; set; }
        public List<GetTransactionsByAccountCodeOrId> getTransactionsByAccountCodeOrIds { get; set; }
    }
}
