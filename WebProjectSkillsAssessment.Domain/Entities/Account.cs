using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectSkillsAssessment.Domain.Entities
{
    public class Account
    {
        [Key]
        public int Code { get; set; }
        public int PersonCode { get; set; }
        [Required]
        public string AccountNumber { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)]
        public decimal  OutstandingAmount { get; set; }   
    }
}
