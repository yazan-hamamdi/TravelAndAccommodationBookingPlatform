using TravelAndAccommodationBookingPlatform.Domain.Models.Common;
using TravelAndAccommodationBookingPlatform.Domain.Models.RoomDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface IRoomService
{
    Task<PaginatedList<RoomDto>> GetAllRoomsAsync(int pageNumber, int pageSize);
}