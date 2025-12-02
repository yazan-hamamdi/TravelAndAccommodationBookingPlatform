using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;

namespace TravelAndAccommodationBookingPlatform.Domain.Services;
public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<List<Hotel>> GetFeaturedDealsAsync(int count)
    {
        var hotels = await _hotelRepository.GetHotelsWithDiscountsAsync();

        var result = hotels
            .Where(h => h.Rooms.Any(r =>
                r.Availability == true &&
                r.RoomDiscounts.Any(rd =>
                    rd.Discount.ValidFrom <= DateTime.Now &&
                    rd.Discount.ValidTo >= DateTime.Now
                )))
            .OrderBy(x => Guid.NewGuid())
            .Take(count)
            .Select(h => new Hotel
            {
                HotelId = h.HotelId,
                HotelName = h.HotelName,
                StarRating = h.StarRating,
                ThumbnailUrl = h.ThumbnailUrl,
                Address = h.Address,
                City = h.City,
                Rooms = h.Rooms
                    .Where(r =>
                        r.Availability == true &&
                        r.RoomDiscounts.Any(rd =>
                            rd.Discount.ValidFrom <= DateTime.Now &&
                            rd.Discount.ValidTo >= DateTime.Now
                        ))
                    .ToList()
            })
            .ToList();

        return result;
    }
}