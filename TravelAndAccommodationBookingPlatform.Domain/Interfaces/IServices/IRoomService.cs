using TravelAndAccommodationBookingPlatform.Domain.Models.Common;
using TravelAndAccommodationBookingPlatform.Domain.Models.RoomDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface IRoomService
{
    Task<PaginatedList<RoomDto>> GetAllRoomsAsync(int pageNumber, int pageSize);
    Task<RoomDto> GetRoomByIdAsync(Guid roomId);
    Task CreateRoomAsync(CreateRoomDto createRoomDto);
    Task UpdateRoomAsync(Guid roomId, UpdateRoomDto updateRoomDto);
    Task DeleteRoomAsync(Guid roomId);
}