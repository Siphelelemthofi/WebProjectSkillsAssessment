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

namespace WebProjectSkillsAssessment.Repository.TransactionRepository
{
    public class TransactionRepository : ITransationRepository
    {
        private readonly DataContext _dataContext;
        public TransactionRepository(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }
        public List<GetTransactionsByAccountCodeOrId> GetTransactionsByAccountCodeOrId(int AccountCode)
        {
            var parameters = new SqlParameter[]
           {
                new SqlParameter("@AccountCode", AccountCode)
            };
            var query = "EXEC [GetTransactionsByAccountCodeOrId] @AccountCode";
            var returnResult = _dataContext.Set<GetTransactionsByAccountCodeOrId>().FromSqlRaw(query, parameters);
            return returnResult.ToList();
        }
        public Transaction GetTransactionDetailsCodeOrId(int AccountCode)
        {
            var parameters = new SqlParameter[]
           {
                new SqlParameter("@AccountCode", AccountCode)
            };
            var query = "EXEC [GetTransactionsDetailsCodeOrId] @AccountCode";
            var returnResult = _dataContext.Set<Transaction>().FromSqlRaw(query, parameters).ToList();
            return returnResult.FirstOrDefault();
        }
        public void AddNewTransaction(Transaction  transaction)
        {
            object[] parameters =
            {
                new SqlParameter("@Code",transaction.Code),
                new SqlParameter("@TransactionDate",transaction.TransactionDate),
                new SqlParameter("@Amount",transaction.Amount),
                new SqlParameter("@Description",transaction.Description)

            };
            var query = "EXEC [AddNewTransaction]  @Code,@TransactionDate,@Amount,@Description";
            _dataContext.Database.ExecuteSqlRaw(query, parameters);
        }
        public void UpdateTransactionInformation(Transaction  transaction)
        {
            object[] parameter = {
              
            new SqlParameter("@Code",transaction.Code),
            new SqlParameter("@AccountCode",transaction.AccountCode),
            new SqlParameter("@TransactionDate",transaction.TransactionDate),
            new SqlParameter("@Amount",transaction.Amount),
            new SqlParameter("@Description",transaction.Description),

            };
            var query = "EXEC [UpdateTransactionsInformationByCode] @Code,@AccountCode,@TransactionDate,@Amount,@Description";
            _dataContext.Database.ExecuteSqlRaw(query, parameter);
        }
    }
}
