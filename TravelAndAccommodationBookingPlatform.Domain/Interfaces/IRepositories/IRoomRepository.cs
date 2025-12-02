using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
public interface IRoomRepository : IBaseRepository<Room>
{
    Task<Room?> GetRoomIfAvailableAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate);
}
