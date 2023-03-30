using AutoMapper;
using TostiTime.API.DTOs;
using TostiTime.Core.Entities;

namespace TostiTime.API.Profiles;

public class OfficeProfile : Profile
{
    public OfficeProfile()
    {
        CreateMap<Office, OfficeDto>();
        CreateMap<Office, OfficeWithoutIronsDto>();
        CreateMap<Office, OfficeWithPersonsDto>();
        CreateMap<OfficeDto, Office>();
        CreateMap<OfficeWithoutIronsDto, Office>();
        CreateMap<OfficeWithPersonsDto, Office>();
    }
}
