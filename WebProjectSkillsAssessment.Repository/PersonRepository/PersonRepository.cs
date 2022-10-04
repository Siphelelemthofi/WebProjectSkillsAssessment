using ManagePeopleWithTheirAccounts.Data.Entities;
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
        public  List<GetAllPersons> GetPersonList(string SearchString)
        {
            try
            {
                object[] parameters =
                {
                new SqlParameter("@SearchString",string.IsNullOrEmpty(SearchString)?(object)DBNull.Value:(object) SearchString)
                };
                var query = "EXEC [GetAllPerson] @SearchString";
                var returnResult = _dataContext.Set<GetAllPersons>().FromSqlRaw(query, parameters);
                return returnResult.ToList();
            }
            catch (SqlException ex)
            {
                throw new(ex.Message);

            }

        }
        public void AddNewPerson (AddNewPerson  addNewPerson)
        {
            try
            {
                object[] parameters =
                {
                new SqlParameter("@Name",addNewPerson.Name),
                new SqlParameter("@Surname",addNewPerson.Surname),
                new SqlParameter("@Id_Number",addNewPerson.Id_number)
            };
                var query = "EXEC [AddNewPerson] @Name,@Surname,@Id_Number";
                _dataContext.Database.ExecuteSqlRaw(query, parameters);
            }
            catch(SqlException ex)
            {
                throw new ( ex.Message);

            }       
        }
        public GetPersonDetailsByCode GetPersonByCodeOrId(int Code)
        {
            object[] parameters = new SqlParameter[]    
            {
                new SqlParameter("@Code",Code)
            };
            var query = "EXEC [GetPersonDetailsByCodeOrId] @Code";
            var PersonDetails = _dataContext.Set<GetPersonDetailsByCode>().FromSqlRaw(query, parameters).ToList();
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
        public void UpdatePersonInformation(UpdateUserInformation updatePersonInformation)
        {
            object[] parameter = {
            new SqlParameter("@Code",updatePersonInformation.Code),
            new SqlParameter("@Name",updatePersonInformation.Name),
            new SqlParameter("@Surname",updatePersonInformation.Surname)

            };
            var query = "EXEC [UpdatepersonInformation] @Code,@Name,@Surname";
            _dataContext.Database.ExecuteSqlRaw(query, parameter);
        }
        public List<GetAllIdNumberForPersons> GetAllIdNumber()
        {
            var query = "EXEC [GetAllPersonIdNumbers]";
            var returnResult = _dataContext.Set<GetAllIdNumberForPersons>().FromSqlRaw(query);
            return returnResult.ToList();
        }
        public bool CheckIfIdNumberExist(string IdNumber)
        {
            var checkIdNumber = (from CountIdNumber in GetAllIdNumber().Where(s => s.Id_number.Equals(IdNumber)) select CountIdNumber).Count();
            if(checkIdNumber > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Person> GetPersonListWithNoAccounts(string SearchString)
        {
            object[] parameters =
            {
                new SqlParameter("@SearchString",string.IsNullOrEmpty(SearchString)?(object)DBNull.Value:(object) SearchString)
            };
            var query = "EXEC [GetAllPersonWithNoAccounts] @SearchString";
            var returnResult = _dataContext.Set<Person>().FromSqlRaw(query, parameters);
            return returnResult.ToList();

        }
    }
}
