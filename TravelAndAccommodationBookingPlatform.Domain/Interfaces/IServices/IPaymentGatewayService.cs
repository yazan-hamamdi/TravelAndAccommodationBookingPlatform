using TravelAndAccommodationBookingPlatform.Domain.Enums;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface IPaymentGatewayService
{
    Task<(string approvalUrl, string transactionId, PaymentMethod paymentMethod)> CreatePaymentAsync(decimal amount, string currency);
    Task ExecutePaymentAsync(string paymentId, string payerId);
}