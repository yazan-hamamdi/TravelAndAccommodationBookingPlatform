using Microsoft.EntityFrameworkCore;
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
}