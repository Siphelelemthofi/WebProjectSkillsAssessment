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
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = string.Empty;
        [Required(ErrorMessage = "Id_number is required")]
        [MaxLength(13)]
        [MinLength(13)]
        public string Id_number { get; set; } = string.Empty;
   }
}
