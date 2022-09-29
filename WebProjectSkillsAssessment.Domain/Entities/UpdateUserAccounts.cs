using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectSkillsAssessment.Domain.Entities
{
    public class UpdateUserAccounts
    {
        [Key]
        public int Code { get; set; }
        public int PersonCode { get; set; }
        [Required]
        [MaxLength(8)]
        [MinLength(8)]
        public string AccountNumber { get; set; } = string.Empty;

    }
}
