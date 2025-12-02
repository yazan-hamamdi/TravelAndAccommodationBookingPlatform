using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class CityRepository : BaseRepository<City>, ICityRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;

    public CityRepository(TravelAndAccommodationBookingDbContext context) : base(context)
    {
        _context = context;
    }
}