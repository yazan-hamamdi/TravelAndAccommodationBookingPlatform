using TravelAndAccommodationBookingPlatform.Domain.Enums;
namespace TravelAndAccommodationBookingPlatform.Domain.Entities;
public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public string? PhoneNumber { get; set; }
    public string Salt { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
}