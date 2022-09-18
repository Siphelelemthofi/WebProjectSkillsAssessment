using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Bussiness.Interface
{
    public interface ITransationRepository
    {
        List<GetTransactionsByAccountCodeOrId> GetTransactionsByAccountCodeOrId(int AccountCode);
        void AddNewTransaction(Transaction transaction);
        Transaction GetTransactionDetailsCodeOrId(int AccountCode);
        void UpdateTransactionInformation(Transaction transaction);
    }
}
