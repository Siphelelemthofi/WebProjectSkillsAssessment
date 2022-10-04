using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeopleWithTheirAccounts.Data.Entities
{
    public class BasePrimaryKey
    {
        [Key]
        public int Code { get; set; }
    }
}
