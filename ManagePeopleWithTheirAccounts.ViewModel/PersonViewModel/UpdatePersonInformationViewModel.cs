using ManagePeopleWithTheirAccounts.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace ManagePeopleWithTheirAccounts.ViewModel.PersonViewModel
{
    public class UpdatePersonInformationViewModel : BasePrimaryKeyViewModelcs
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = string.Empty;
        public string Id_number { get; set; } = string.Empty;
    }
}
