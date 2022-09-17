using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Domain.Manager
{
    public class ValidationsManager
    {
        private readonly IPersonRepository _personRepository;
        public ValidationsManager(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public bool ValidateIdNumber(string IdNumber)
        {
            var CheckIfIdExist = _personRepository.GetAllIdNumber().Where(s =>s.Id_number.Equals(IdNumber)).Count();
            if(CheckIfIdExist > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
