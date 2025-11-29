using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq.Protected;
using Moq;
using System.Net;
using TokenGenerator;
using TravelAndAccommodationBookingPlatform.Domain.Enums;

namespace TravelAndAccommodationBookingPlatform.Tests.Services;
    public class JwtGeneratorServiceUnitTests
    {
        private readonly JwtGeneratorService _jwtGeneratorService;

    public JwtGeneratorServiceUnitTests()
    {
        var inMemorySettings = new Dictionary<string, string>
    {
        { "Authentication:SecretForKey", "thisisthesecretforgeneratingakey(mustbeatleast32bitlong)" },
        { "Authentication:Issuer", "https://localhost:7278" },
        { "Authentication:Audience", "api" },
        { "Authentication:TokenExpirationHours", "1" }
    };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext)
            .Returns(new DefaultHttpContext { Connection = { RemoteIpAddress = IPAddress.Parse("127.0.0.1") } });

        _jwtGeneratorService = new JwtGeneratorService(configuration, httpContextAccessorMock.Object);
    }


    [Fact]
        public async Task GenerateToken_ShouldReturnToken()
        {
            var userId = Guid.NewGuid();
            var username = "testuser";
            var userRole = UserRole.User;

            var token = await _jwtGeneratorService.GenerateTokenAsync(userId, username, userRole);

            Assert.NotNull(token);
            Assert.Contains(".", token);
        }
    }