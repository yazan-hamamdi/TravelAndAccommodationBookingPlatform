using TravelAndAccommodationBookingPlatform.Domain.Models.AmenityDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Models.RoomDtos;
public class RoomAmenityDto
{
    public Guid RoomAmenityId { get; set; }
    public Guid RoomId { get; set; }
    public Guid AmenityId { get; set; }
    public AmenityDto Amenity { get; set; }
}