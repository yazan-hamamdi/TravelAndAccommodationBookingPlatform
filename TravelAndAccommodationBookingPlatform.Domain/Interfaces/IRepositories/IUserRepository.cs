using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
public interface IUserRepository : IBaseRepository<User>
{
 Task<User?> GetUserByUsernameAsync(string username);
 Task<User?> GetUserByEmailAsync(string email);
 Task CreateUserAsync(User user);
}