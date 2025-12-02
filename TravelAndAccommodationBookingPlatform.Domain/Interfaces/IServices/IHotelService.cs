using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface IHotelService
{
    Task<List<Hotel>> GetFeaturedDealsAsync(int count);
}