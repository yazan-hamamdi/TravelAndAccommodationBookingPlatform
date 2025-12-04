using TravelAndAccommodationBookingPlatform.Domain.Models.PaymentDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface IInvoiceService
{
    byte[] GenerateInvoiceAsync(PaymentDto paymentDto);
}