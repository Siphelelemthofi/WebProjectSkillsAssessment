using ManagePeopleWithTheirAccounts.Data.Entities;
using ManagePeopleWithTheirAccounts.ViewModel.PersonViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public List<ViewModel.PersonViewModel.GetAllPersonsViewModel> GetListOfPerson(string SearchName)
        {
            var GetAllPerson =  _personRepository.GetPersonList(SearchName);
            return Domain.ObjectMapper.Mapper.Map<List<GetAllPersonsViewModel>>(GetAllPerson);
        }
        public void AddNewPerson(AddNewPersonViewModel addNewPersonViewModel)
        {
            var AddNewPerson = Domain.ObjectMapper.Mapper.Map<AddNewPerson>(addNewPersonViewModel);
            _personRepository.AddNewPerson(AddNewPerson);
        }
        public GetPersonDetailsByCodeViewModel GetPersonDetailsByIdOrCode(int Code)
        {
            var GetPersonDetailByCode = _personRepository.GetPersonByCodeOrId(Code);
            return Domain.ObjectMapper.Mapper.Map<GetPersonDetailsByCodeViewModel>(GetPersonDetailByCode);
        }
        public void UpdatePersonInformation(UpdatePersonInformationViewModel updatePersonInformationViewModel)
        {
             var UpdatePersonInformation = Domain.ObjectMapper.Mapper.Map<UpdateUserInformation>(updatePersonInformationViewModel);
            _personRepository.UpdatePersonInformation(UpdatePersonInformation);
        }
        public UpdatePersonInformationViewModel GetInformationToUpdate(int Code)
        {
            UpdatePersonInformationViewModel updatePersonInformation = new UpdatePersonInformationViewModel();
            var GetPersonByCode =  _personRepository.GetPersonByCodeOrId(Code);
            updatePersonInformation.Code = GetPersonByCode.Code;
            updatePersonInformation.Name = GetPersonByCode.Name;
            updatePersonInformation.Surname = GetPersonByCode.Surname;
            updatePersonInformation.Id_number = GetPersonByCode.Id_number;
            return updatePersonInformation;
        }
    }
}
