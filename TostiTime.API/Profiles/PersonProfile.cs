using AutoMapper;
using TostiTime.API.DTOs;
using TostiTime.Core.Entities;

namespace TostiTime.API.Profiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<Person, PersonWithoutReservationsDto>();
        CreateMap<PersonDto, Person>();
        CreateMap<PersonWithoutReservationsDto, Person>();
    }
}
