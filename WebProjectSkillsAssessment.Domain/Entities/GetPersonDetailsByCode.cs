using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace ManagePeopleWithTheirAccounts.Data.Entities
{
    public class GetPersonDetailsByCode : BasePrimaryKey
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Id_number { get; set; } = string.Empty;
    }
}
