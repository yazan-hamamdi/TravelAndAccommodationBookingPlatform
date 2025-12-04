using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;
public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    private readonly TravelAndAccommodationBookingDbContext _context;
    private readonly IPaginationService _paginationService;


    public CartRepository(TravelAndAccommodationBookingDbContext context, IPaginationService paginationService) : base(context)
    {
        _context = context;
        _paginationService = paginationService;
    }

    public async Task<IEnumerable<Cart>> GetCartItemsByUserIdAsync(Guid userId)
    {
        return await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task ClearCartAsync(Guid userId)
    {
        var cartItems = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
        if (cartItems.Any())
        {
            _context.Carts.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<(IEnumerable<Cart> Items, int TotalCount)> GetAllPagedAsync(Guid userId, int pageNumber, int pageSize)
    {
        var cartItems = _context.Carts.AsQueryable();
        var (paginatedCartItems, totalCount) = await _paginationService.PaginateAsync(cartItems, pageSize, pageNumber);
        return (paginatedCartItems, totalCount);
    }

    public async Task<bool> HasDateConflictAsync(Guid userId, Guid roomId, DateTime checkInDate, DateTime checkOutDate)
    {
        return await _context.Carts.AnyAsync(c =>
            c.UserId == userId &&
            c.RoomId == roomId &&
            !(c.CheckOutDate <= checkInDate || c.CheckInDate >= checkOutDate)
        );
    }
}