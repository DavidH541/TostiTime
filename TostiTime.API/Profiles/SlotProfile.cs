using AutoMapper;
using TostiTime.API.DTOs;
using TostiTime.Core.Entities;

namespace TostiTime.API.Profiles;

public class SlotProfile : Profile
{
    public SlotProfile()
    {
        CreateMap<Slot, SlotWithLastReservationDto>();
        CreateMap<SlotWithLastReservationDto, Slot>();
    }
}
