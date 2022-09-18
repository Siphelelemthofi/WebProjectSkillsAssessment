using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectSkillsAssessment.Domain.Entities
{
    public class UserLogin
    {
        [Key]
        [Required]
        public string UserName { get; set; } =string.Empty;
        [Required]
        public string UserPassword { get; set; }= string.Empty;
    }
}
