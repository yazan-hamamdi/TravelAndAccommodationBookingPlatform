namespace TravelAndAccommodationBookingPlatform.Domain.Models.PaymentDtos;
public class ConfirmPaymentRequestDto
{
    public Guid PaymentId { get; set; }
    public string PayerId { get; set; }
}