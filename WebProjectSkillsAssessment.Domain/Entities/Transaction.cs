using ManagePeopleWithTheirAccounts.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectSkillsAssessment.Domain.Entities
{
    public class Transaction : BasePrimaryKey
    {
       
        public int AccountCode { get; set; }
 
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }
 
        public decimal Amount { get; set; }
      
        public string Description { get; set; } = string.Empty; 
    }
}
