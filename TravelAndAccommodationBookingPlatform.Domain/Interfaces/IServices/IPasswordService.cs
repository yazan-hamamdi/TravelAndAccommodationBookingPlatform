namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
    public interface IPasswordService
    {
        public byte[] GenerateSalt();
        public string? GenerateHashedPassword(string password, byte[] salt);
        public bool VerifyPassword(string userPassword, string hashedPassword, byte[] salt);
    }