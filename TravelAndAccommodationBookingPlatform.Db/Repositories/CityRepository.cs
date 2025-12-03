using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Enums;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class CityRepository : BaseRepository<City>, ICityRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;
    private readonly IPaginationService _paginationService;

    public CityRepository(TravelAndAccommodationBookingDbContext context, IPaginationService paginationService) : base(context)
    {
        _context = context;
        _paginationService = paginationService;
    }

    public async Task<List<City>> GetTrendingDestinationsAsync(int count)
    {
        return await _context.Cities
            .Include(c => c.Hotels)
            .ThenInclude(h => h.Rooms)
            .ThenInclude(r => r.BookingDetails)
            .ThenInclude(bd => bd.Booking)
            .OrderByDescending(c => c.Hotels
                .Sum(h => h.Rooms
                    .Sum(r => r.BookingDetails
                        .Count(bd => bd.Booking.Status == BookingStatus.Confirmed))))
            .Take(count)
            .ToListAsync();
    }

    public async Task<(IEnumerable<City> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize)
    {
        var cities = _context.Cities.AsQueryable();
        var (paginatedCities, totalCount) = await _paginationService.PaginateAsync(cities, pageSize, pageNumber);
        return (paginatedCities, totalCount);
    }

    public async Task<City> GetCityByNameAsync(string cityName)
    {
        return await _context.Cities.FirstOrDefaultAsync(c => c.CityName.ToLower() == cityName.ToLower());
    }

    public async Task<City> GetCityByIdAsync(Guid cityId)
    {
        return await _context.Cities.FirstOrDefaultAsync(c => c.CityId == cityId);
    }
}