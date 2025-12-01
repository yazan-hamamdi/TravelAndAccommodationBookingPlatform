using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class BookingRepository : BaseRepository<Booking>, IBookingRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;

    public BookingRepository(TravelAndAccommodationBookingDbContext context) : base(context)
    {
        _context = context;
    }
}