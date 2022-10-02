using ManagePeopleWithTheirAccounts.ViewModel.PersonViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace ManagePeopleWithTheirAccounts.Business.PersonBusiness
{
    public class PersonBusiness
    {
        private readonly WebProjectSkillsAssessment.Bussiness.Interface.IPersonRepository _personRepository;
        public PersonBusiness(WebProjectSkillsAssessment.Bussiness.Interface.IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public List<ViewModel.PersonViewModel.PersonsViewModel> GetListOfPerson(string SearchName)
        {
            var GetAllPerson =  _personRepository.GetPersonList(SearchName);
            return Domain.ObjectMapper.Mapper.Map<List<PersonsViewModel>>(GetAllPerson);
        }
        public void AddNewPerson(AddNewPersonViewModel addNewPersonViewModel)
        {
            Domain.ObjectMapper.Mapper.Map<AddNewPersonViewModel>(_personRepository.AddNewPerson(addNewPersonViewModel));
             
        }
    }
}
