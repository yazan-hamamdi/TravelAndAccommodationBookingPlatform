using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;

    public PaymentRepository(TravelAndAccommodationBookingDbContext context) : base(context)
    {
        _context = context;
    }
}