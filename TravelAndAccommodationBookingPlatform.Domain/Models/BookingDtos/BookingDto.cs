using TravelAndAccommodationBookingPlatform.Domain.Models.UserDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Models.BookingDtos;
public class BookingDto
{
    public Guid BookingId { get; set; }
    public string Status { get; set; }
    public UserDto User { get; set; }
    public List<BookingDetailDto> BookingDetails { get; set; }
}