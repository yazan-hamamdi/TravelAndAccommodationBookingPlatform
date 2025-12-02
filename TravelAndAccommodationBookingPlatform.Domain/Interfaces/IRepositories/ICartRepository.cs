using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
public interface ICartRepository : IBaseRepository<Cart>
{
    Task<IEnumerable<Cart>> GetCartItemsByUserIdAsync(Guid userId);
    Task ClearCartAsync(Guid userId);
}