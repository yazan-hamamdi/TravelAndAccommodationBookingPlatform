namespace TravelAndAccommodationBookingPlatform.Domain.Entities;
public class BookingDetail
{
    public Guid BookingDetailsId { get; set; } = Guid.NewGuid();
    public Guid BookingId { get; set; }
    public Guid RoomId { get; set; }
    public Guid DiscountId { get; set; }
    public decimal Price { get; set; }

    public Booking Booking { get; set; }
    public Room Room { get; set; }
    public Discount Discount { get; set; }
}