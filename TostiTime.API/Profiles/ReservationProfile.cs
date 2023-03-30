using AutoMapper;
using TostiTime.API.DTOs;
using TostiTime.Core.Entities;

namespace TostiTime.API.Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile() 
    {
        CreateMap<Reservation, ReservationDto>();
        CreateMap<ReservationDto, Reservation>();
    }
}
