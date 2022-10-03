using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeopleWithTheirAccounts.ViewModel.PersonViewModel
{
    public class AddNewPersonViewModel
    {
        [Required]
        public string name { get; set; } = string.Empty;
        [Required]
        public string surname { get; set; } = string.Empty;
        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        public string Id_number { get; set; } = string.Empty;
   }
}
