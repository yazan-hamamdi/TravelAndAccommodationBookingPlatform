using AutoMapper;
using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Profiles;
public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.BookingDetails, opt => opt.MapFrom(src => src.BookingDetails));
    }
}