using TravelAndAccommodationBookingPlatform.Domain.Enums;
namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface ITokenGeneratorService
{
    string GenerateToken(Guid userId, string username, UserRole role);
}