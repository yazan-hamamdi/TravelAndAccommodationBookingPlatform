using TravelAndAccommodationBookingPlatform.Domain.Models.BookingDtos;
using TravelAndAccommodationBookingPlatform.Domain.Models.HotelDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface IBookingService
{
    Task<List<RecentlyVisitedHotelDto>> GetRecentlyVisitedHotelsAsync(Guid userId, int count);
    Task<CheckoutDto> CreateBookingFromCartAsync(CheckoutRequestDto requestDto);
}