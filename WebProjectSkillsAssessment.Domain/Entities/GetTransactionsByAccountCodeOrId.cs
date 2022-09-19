using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectSkillsAssessment.Domain.Entities
{
    public class GetTransactionsByAccountCodeOrId
    {
        [Key]
        public int Code { get; set; }
        public int AccountCode { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
