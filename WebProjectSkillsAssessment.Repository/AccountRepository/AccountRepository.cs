using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;
using WebProjectSkillsAssessment.Repository.Data;

namespace WebProjectSkillsAssessment.Repository.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _dataContext;

        public AccountRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddNewAccount(Account account)
        {
            object[] parameters =
            {
                new SqlParameter("@PersonCode",account.Code),
                new SqlParameter("@AccountNumber",account.AccountNumber)
            };
            var query = "EXEC [AddNewUserAccount]  @PersonCode,@AccountNumber";
            _dataContext.Database.ExecuteSqlRaw(query, parameters);
        }
        public List<Account> GetPersonAccountByCodeOrId(int Code)
        {
            object[] parameters =
            {
                new SqlParameter("@Code",Code),
            };
            var query = "EXEC [GetPersonAccountByCodeOrId] @Code";
            var returnResult = _dataContext.Set<Account>().FromSqlRaw(query, parameters);
            return returnResult.ToList();
        }
        public Account GetAccountDetails(string AccountNumber)
        {
            object[] parameters =
            {
                new SqlParameter("@AccountNumber",AccountNumber)
            };
            var query = "EXEC [GetAccountDetailByAccountNumber] @AccountNumber";
             var GetAccountDetails =_dataContext.Set<Account>().FromSqlRaw(query, parameters).ToList();
            return GetAccountDetails.FirstOrDefault();
        }
        public void UpdateAccountInformation(Account account)
        {
            object[] parameter = {
            new SqlParameter("@Code",account.Code),
            new SqlParameter("@AccountNumber",account.AccountNumber),
            new SqlParameter("@OutstandingAmount",account.OutstandingAmount),

            };
            var query = "EXEC [UpdateAccountInformationByCode] @Code,@AccountNumber";
            _dataContext.Database.ExecuteSqlRaw(query, parameter);
        }
        public List<GetAllAccountNumber> GetAllAccountNumber()
        {
            var query = "EXEC [GetAllAccountNumber]";
            var returnResult = _dataContext.Set<GetAllAccountNumber>().FromSqlRaw(query);
            return returnResult.ToList();
        }
        public bool CheckAccountNumber(string AccountNumber)
        {
            int CheckIfAccountExist = (from getAllAccounts in GetAllAccountNumber().Where(a => a.AccountNumber.Equals(AccountNumber)) select getAllAccounts).Count();
            if(CheckIfAccountExist > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public decimal GetCurrentAccountBalance(int Code)
        {
             decimal checkBalance =  (from getBalance in GetPersonAccountByCodeOrId(Code) where getBalance.Code.Equals(Code) select getBalance.OutstandingAmount).FirstOrDefault();
             return checkBalance;
            
        }
    }
}
