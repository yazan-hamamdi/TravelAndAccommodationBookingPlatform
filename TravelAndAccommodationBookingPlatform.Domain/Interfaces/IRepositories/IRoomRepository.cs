using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
public interface IRoomRepository : IBaseRepository<Room>
{
    Task<Room?> GetRoomIfAvailableAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate);
    Task<(IEnumerable<Room> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize);
    Task<Room?> GetRoomByHotelAndNumberAsync(Guid hotelId, string roomNumber);
}
