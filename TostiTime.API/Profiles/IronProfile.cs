using AutoMapper;
using TostiTime.API.DTOs;
using TostiTime.Core.Entities;

namespace TostiTime.API.Profiles;

public class IronProfile : Profile
{
    public IronProfile()
    {
        CreateMap<Iron, IronDto>();
        CreateMap<Iron, IronWithoutSlotsDto>();
        CreateMap<IronDto, Iron>();
        CreateMap<IronWithoutSlotsDto, Iron>();
    }
}
