using AutoMapper;
using ManagePeopleWithTheirAccounts.ViewModel.PersonViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectSkillsAssessment.Domain.Entities;

namespace ManagePeopleWithTheirAccounts.Domain
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var Mapping = new MapperConfiguration(map =>
            {
               map.CreateMap<Person, PersonsViewModel>().ReverseMap(); map.CreateMap<AddNewPerson, AddNewPersonViewModel>().ReverseMap();
            });
            var mapper = Mapping.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
