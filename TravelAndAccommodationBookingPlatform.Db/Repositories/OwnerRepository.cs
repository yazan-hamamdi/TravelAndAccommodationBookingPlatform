using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;

    public OwnerRepository(TravelAndAccommodationBookingDbContext context) : base(context)
    {
        _context = context;
    }
}