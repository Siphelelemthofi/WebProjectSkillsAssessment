using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjectSkillsAssessment.ViewModel.PersonViewModel
{
    public class PersonViewModel
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Id_number { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
    }
}
