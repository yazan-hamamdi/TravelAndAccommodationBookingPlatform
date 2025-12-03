using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Enums;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;
    private readonly IPaginationService _paginationService;


    public RoomRepository(TravelAndAccommodationBookingDbContext context, IPaginationService paginationService) : base(context)
    {
        _context = context;
        _paginationService = paginationService;
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

    public async Task<(IEnumerable<Room> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize)
    {
        var rooms = _context.Rooms.AsQueryable();
        var (paginatedRooms, totalCount) = await _paginationService.PaginateAsync(rooms, pageSize, pageNumber);
        return (paginatedRooms, totalCount);
    }

    public async Task<Room?> GetRoomByHotelAndNumberAsync(Guid hotelId, string roomNumber)
    {
        return await _context.Rooms
            .FirstOrDefaultAsync(r => r.HotelId == hotelId && r.RoomNumber == roomNumber);
    }
}