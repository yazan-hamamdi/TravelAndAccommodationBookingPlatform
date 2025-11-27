using TravelAndAccommodationBookingPlatform.Domain.Enums;
namespace TravelAndAccommodationBookingPlatform.Domain.Entities;
public class Room
{
    public Guid RoomId { get; set; } = Guid.NewGuid();
    public Guid HotelId { get; set; }
    public string RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public RoomType RoomType { get; set; }
    public string Description { get; set; }
    public int AdultsCapacity { get; set; }
    public int ChildrenCapacity { get; set; }
    public bool Availability { get; set; }

    public Hotel Hotel { get; set; }
    public ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
    public ICollection<RoomDiscount> RoomDiscounts { get; set; } = new List<RoomDiscount>();
    public ICollection<Image> Images { get; set; } = new List<Image>();
    public ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
}