using ManagePeopleWithTheirAccounts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Bussiness.Interface
{
    public interface IPersonRepository
    {

        List<GetAllPersons> GetPersonList(string SearchString);
        void AddNewPerson(AddNewPerson addNewPerson);
        void UpdatePersonInformation(UpdateUserInformation  updateUserInformation);
        void DeleteUserWithNoAccountOrAccountClosed(int Code);
        GetPersonDetailsByCode GetPersonByCodeOrId(int Code);
        List<GetAllIdNumberForPersons> GetAllIdNumber();
        bool CheckIfIdNumberExist(string IdNumber);
        List<Person> GetPersonListWithNoAccounts(string SearchString);

    }
}
