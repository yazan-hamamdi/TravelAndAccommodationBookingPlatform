using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
public interface ICartRepository : IBaseRepository<Cart>
{
    Task<IEnumerable<Cart>> GetCartItemsByUserIdAsync(Guid userId);
    Task ClearCartAsync(Guid userId);
    Task<(IEnumerable<Cart> Items, int TotalCount)> GetAllPagedAsync(Guid userId, int pageNumber, int pageSize);
    Task<bool> HasDateConflictAsync(Guid userId, Guid roomId, DateTime checkInDate, DateTime checkOutDate);
}