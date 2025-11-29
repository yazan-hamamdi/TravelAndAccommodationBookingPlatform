using TravelAndAccommodationBookingPlatform.Domain.Enums;
namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface ITokenGeneratorService
{
    Task<string> GenerateTokenAsync(Guid userId, string username, UserRole role);
}