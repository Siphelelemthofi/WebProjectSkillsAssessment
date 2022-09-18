using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectSkillsAssessment.Domain.Entities
{
    public class Person
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; }= string.Empty;
        public string Id_number { get; set; } = string.Empty;
        


    }
}
