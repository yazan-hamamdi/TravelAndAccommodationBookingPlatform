using TravelAndAccommodationBookingPlatform.Domain.Models.UserDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(Guid userId);
}