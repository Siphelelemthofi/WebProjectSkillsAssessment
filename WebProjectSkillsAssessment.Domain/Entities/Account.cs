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
    public class Account : BasePrimaryKey
    {
        public int PersonCode { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public decimal  OutstandingAmount { get; set; }   
    }
}
