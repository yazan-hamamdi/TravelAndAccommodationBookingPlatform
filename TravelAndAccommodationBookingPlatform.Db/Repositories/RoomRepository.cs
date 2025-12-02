using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Enums;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;

    public RoomRepository(TravelAndAccommodationBookingDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Room?> GetRoomIfAvailableAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate)
    {
        return await _context.Rooms
            .Include(r => r.BookingDetails)
            .ThenInclude(b => b.Booking)
            .Include(r => r.RoomDiscounts)
            .ThenInclude(rd => rd.Discount)
            .FirstOrDefaultAsync(r => r.RoomId == roomId &&
                                      r.BookingDetails.All(b =>
                                          b.Booking.Status != BookingStatus.Confirmed ||
                                          b.CheckOutDate <= checkInDate ||
                                          b.CheckInDate >= checkOutDate) &&
                                      r.Availability == true);
    }
}