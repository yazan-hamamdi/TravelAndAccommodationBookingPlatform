using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
public interface IBookingRepository : IBaseRepository<Booking>
{
    Task<List<Hotel>> GetRecentlyVisitedHotelsAsync(Guid userId, int count);
    Task<Booking?> GetBookingWithPaymentByIdAsync(Guid bookingId);
}