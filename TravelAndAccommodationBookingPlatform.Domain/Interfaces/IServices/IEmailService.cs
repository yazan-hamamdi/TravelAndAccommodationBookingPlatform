using TravelAndAccommodationBookingPlatform.Domain.Models.EmailDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface IEmailService
{
    Task SendEmailAsync(EmailDto emailDto);
}