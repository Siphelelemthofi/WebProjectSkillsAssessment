using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Bussiness.Interface;
using WebProjectSkillsAssessment.Domain.Entities;
using WebProjectSkillsAssessment.Repository.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebProjectSkillsAssessment.Repository.PersonRepository
{
    public class PersonRepository: IPersonRepository
    {
        private readonly DataContext _dataContext;

        public PersonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public  List<Person> GetPersonList(string SearchString)
        {
            object[] parameters =
            {
                new SqlParameter("@SearchString",string.IsNullOrEmpty(SearchString)?(object)DBNull.Value:(object) SearchString)
            };
            var query = "EXEC [GetAllPerson] @SearchString";
            var returnResult = _dataContext.Set<Person>().FromSqlRaw(query, parameters);
            return returnResult.ToList();
             
        }
        public void AddNewPerson (Person person)
        {
            object[] parameters =
            {
                new SqlParameter("@Name",person.Name),
                new SqlParameter("@Surname",person.Surname),
                new SqlParameter("@Id_Number",person.Id_number)
            };
            var query = "EXEC [AddNewPerson] @Name,@Surname,@Id_Number";
            _dataContext.Database.ExecuteSqlRaw(query, parameters);
        }
        public Person GetPersonByCodeOrId(int Code)
        {
            object[] parameters =
            {
                new SqlParameter("@Code",Code)
            };
            var query = "EXEC [GetPersonDetailsByCodeOrId] @Code";
            var PersonDetails = _dataContext.Set<Person>().FromSqlRaw(query, parameters).ToList();
            return PersonDetails.FirstOrDefault();    
        }
        public void DeleteUserWithNoAccountOrAccountClosed(int Code)
        {
            object[] parameter =
            {
                new SqlParameter("@Code",Code)
            };
                var query = "EXEC [DeletePerson] @Code";
            _dataContext.Database.ExecuteSqlRaw(query, parameter);
        }
        public void UpdatePersonInformation(Person person)
        {
            object[] parameter = {
            new SqlParameter("@Code",person.Code),
            new SqlParameter("@Name",person.Name),
            new SqlParameter("@Surname",person.Surname)
          

            };
            var query = "EXEC [UpdatepersonInformation] @Code,@Name,@Surname";
            _dataContext.Database.ExecuteSqlRaw(query, parameter);
        }
    }
}
