using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;

    public CartRepository(TravelAndAccommodationBookingDbContext context) : base(context)
    {
        _context = context;
    }
}