using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;

    public RoomRepository(TravelAndAccommodationBookingDbContext context) : base(context)
    {
        _context = context;
    }
}