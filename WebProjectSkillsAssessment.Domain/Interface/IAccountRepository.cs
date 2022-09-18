using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Bussiness.Interface
{
    public interface IAccountRepository
    {
        void AddNewAccount(Account account);
        List<Account> GetPersonAccountByCodeOrId(int Code);
        Account GetAccountDetails(string AccountNumber);
        void UpdateAccountInformation(Account account);
        bool CheckAccountNumber(string AccountNumber);
        decimal GetCurrentAccountBalance(int Code);
    }
}
