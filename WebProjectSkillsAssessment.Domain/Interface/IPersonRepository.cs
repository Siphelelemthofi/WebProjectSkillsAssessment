﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace WebProjectSkillsAssessment.Bussiness.Interface
{
    public interface IPersonRepository
    {
        bool isUserValidToLogin(UserLogin userLogin);
        List<Person> GetPersonList(string SearchString);
        void AddNewPerson(AddNewPerson  addNewPerson);
        void UpdatePersonInformation(Person Person);
        void DeleteUserWithNoAccountOrAccountClosed(int Code);
        Person GetPersonByCodeOrId(int Code);
        List<GetAllIdNumberForPersons> GetAllIdNumber();
        bool CheckIfIdNumberExist(string IdNumber);
        List<Person> GetPersonListWithNoAccounts(string SearchString);
    }
}
