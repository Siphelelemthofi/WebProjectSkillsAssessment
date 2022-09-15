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
        public List<Transaction> GetTransactionsByAccountCodeOrId(int AccountCode)
        {
            var parameters = new SqlParameter[]
           {
                new SqlParameter("@AccountCode", AccountCode)
            };
            var query = "EXEC [GetTransactionsByAccountCodeOrId] @AccountCode";
            var returnResult = _dataContext.Set<Transaction>().FromSqlRaw(query, parameters);
            return returnResult.ToList();
        }


    }
}
