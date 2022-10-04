using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeopleWithTheirAccounts.Data.Entities
{
    public class GetAllPersons : BasePrimaryKey
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Id_number { get; set; } = string.Empty;
    }
}
