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
                new SqlParameter("@Code",account.Code),
                new SqlParameter("@AccountNumber",account.AccountNumber)
                
            };
            var query = "EXEC [AddNewUserAccount]  @Code,@AccountNumber";
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
        public void UpdateAccountInformation(Transaction transaction)
        {
            object[] parameter = {
            new SqlParameter("@Code",transaction.Code),
            new SqlParameter("@TransactionDate",transaction.TransactionDate),
            new SqlParameter("@CaptureDate",transaction.CaptureDate),
            new SqlParameter("@Money",transaction.Amount),

            };
            var query = "EXEC [UpdateAccountInformation] @Code,@TransactionDate,@CaptureDate,@Money";
            _dataContext.Database.ExecuteSqlRaw(query, parameter);
        }
    }
}
