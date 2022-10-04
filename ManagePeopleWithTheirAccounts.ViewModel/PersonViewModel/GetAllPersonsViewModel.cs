using ManagePeopleWithTheirAccounts.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeopleWithTheirAccounts.ViewModel.PersonViewModel
{
    public class GetAllPersonsViewModel : BasePrimaryKeyViewModelcs
    {
        public string Name { get; set; } = string.Empty;
 
        public string Surname { get; set; } = string.Empty;
    
        public string Id_number { get; set; } = string.Empty;
    }
}
