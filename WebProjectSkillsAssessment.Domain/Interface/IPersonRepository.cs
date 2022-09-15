using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Bussiness.Interface
{
    public interface IPersonRepository
    {
         List<Person> GetPersonList(string SearchString);
         void AddNewPerson(Person person);
        void UpdatePersonInformation(Person person);
        void DeleteUserWithNoAccountOrAccountClosed(int Code);
        Person GetPersonByCodeOrId(int Code);
    }
}
