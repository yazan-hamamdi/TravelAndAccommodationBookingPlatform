using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Enums;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
using TravelAndAccommodationBookingPlatform.Domain.Models.SearchDtos;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;
    private readonly IPaginationService _paginationService;

    public HotelRepository(TravelAndAccommodationBookingDbContext context, IPaginationService paginationService) : base(context)
    {
        _context = context;
        _paginationService = paginationService;
    }

    public async Task<(IEnumerable<Hotel>, int TotalCount)> SearchHotelsAsync(SearchRequestDto searchRequest,
       int pageSize, int pageNumber)
    {
        var hotelsQuery = _context.Hotels
            .Include(h => h.City)
            .Include(h => h.Rooms)
            .ThenInclude(r => r.BookingDetails)
            .ThenInclude(bd => bd.Booking)
            .Include(h => h.Rooms)
            .ThenInclude(r => r.RoomAmenities)
            .ThenInclude(ra => ra.Amenity)
            .Include(h => h.Rooms)
            .ThenInclude(r => r.Images)
            .Include(h => h.Rooms)
            .ThenInclude(r => r.RoomDiscounts)
            .ThenInclude(rd => rd.Discount)
            .Where(h => h.HotelName.ToLower().Contains(searchRequest.Query.ToLower()) ||
                        h.City.CityName.ToLower().Contains(searchRequest.Query.ToLower()))
            .Where(h => h.Rooms.Count(r =>
                    r.Availability == true &&
                    r.AdultsCapacity >= searchRequest.Adults &&
                    r.ChildrenCapacity >= searchRequest.Children &&
                    !r.BookingDetails.Any(bd =>
                        bd.Booking.Status == BookingStatus.Confirmed &&
                        (bd.CheckInDate < searchRequest.CheckOutDate && bd.CheckOutDate > searchRequest.CheckInDate)
                    )
                ) >= searchRequest.Rooms
            )
            .Select(h => new Hotel
            {
                HotelId = h.HotelId,
                HotelName = h.HotelName,
                StarRating = h.StarRating,
                Latitude = h.Latitude,
                Longitude = h.Longitude,
                City = h.City,
                Rooms = h.Rooms
                    .Where(r =>
                        r.Availability == true &&
                        r.AdultsCapacity >= searchRequest.Adults &&
                        r.ChildrenCapacity >= searchRequest.Children &&
                        !r.BookingDetails.Any(bd =>
                            bd.Booking.Status == BookingStatus.Confirmed &&
                            (bd.CheckInDate < searchRequest.CheckOutDate && bd.CheckOutDate > searchRequest.CheckInDate)
                        )
                    )
                    .Select(r => new Room
                    {
                        RoomId = r.RoomId,
                        HotelId = r.HotelId,
                        RoomNumber = r.RoomNumber,
                        PricePerNight = r.PricePerNight,
                        RoomType = r.RoomType,
                        Description = r.Description,
                        AdultsCapacity = r.AdultsCapacity,
                        ChildrenCapacity = r.ChildrenCapacity,
                        Availability = r.Availability,
                        RoomAmenities = r.RoomAmenities,
                        Images = r.Images,
                        RoomDiscounts = r.RoomDiscounts
                            .Where(rd =>
                                rd.Discount.ValidFrom <= searchRequest.CheckInDate &&
                                rd.Discount.ValidTo >= searchRequest.CheckInDate
                            )
                            .OrderByDescending(rd => rd.Discount.DiscountPercentageValue)
                            .ToList()
                    })
                    .ToList()
            })
            .AsQueryable();

        var (paginatedHotels, totalCount) = await _paginationService.PaginateAsync(hotelsQuery, pageSize, pageNumber);

        return (paginatedHotels, totalCount);
    }

    public async Task<List<Hotel>> GetFeaturedDealsAsync(int count)
    {
        return await _context.Hotels
            .Include(h => h.City)
            .Include(h => h.Rooms)
            .ThenInclude(r => r.RoomDiscounts)
            .ThenInclude(rd => rd.Discount)
            .Where(h => h.Rooms.Any(r =>
                r.RoomDiscounts.Any(rd =>
                    rd.Discount.ValidFrom <= DateTime.Now &&
                    rd.Discount.ValidTo >= DateTime.Now) &&
                r.Availability == true))
            .OrderBy(h => Guid.NewGuid())
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
                        r.RoomDiscounts.Any(rd =>
                            rd.Discount.ValidFrom <= DateTime.Now &&
                            rd.Discount.ValidTo >= DateTime.Now) &&
                        r.Availability == true)
                    .ToList()
            })
            .ToListAsync();
    }

    public async Task<(IEnumerable<Hotel> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize)
    {
        var hotels = _context.Hotels.AsQueryable();
        var (paginatedHotels, totalCount) = await _paginationService.PaginateAsync(hotels, pageSize, pageNumber);
        return (paginatedHotels, totalCount);
    }
}