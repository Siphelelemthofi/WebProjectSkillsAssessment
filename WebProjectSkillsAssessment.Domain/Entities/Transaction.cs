using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectSkillsAssessment.Domain.Entities
{
    public class Transaction
    {
        [Key]
        public int Code { get; set; }
        public int AccountCode { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal Amount { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty; 
    }
}
