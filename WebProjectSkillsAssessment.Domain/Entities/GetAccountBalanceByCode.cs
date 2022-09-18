using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectSkillsAssessment.Domain.Entities
{
    public class GetAccountBalanceByCode
    {
        [Key]
        public int Code { get; set; }
    }
}
