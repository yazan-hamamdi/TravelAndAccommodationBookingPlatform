using InvoiceGenerator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PasswordHashing;
using PaymentGateway;
using PayPal.Api;
using QuestPDF.Infrastructure;
using System.Text;
using TokenGenerator;
using TravelAndAccommodationBookingPlatform.API.Controllers;
using TravelAndAccommodationBookingPlatform.API.Extensions;
using TravelAndAccommodationBookingPlatform.API.Middlewares;
using TravelAndAccommodationBookingPlatform.Db.DbContext;
using TravelAndAccommodationBookingPlatform.Db.DbServices;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using TravelAndAccommodationBookingPlatform.Domain.Enums;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
using TravelAndAccommodationBookingPlatform.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerWithJwtAuth();

builder.Services.AddDbContext<TravelAndAccommodationBookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Authentication:Issuer"],
                    ValidAudience = builder.Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
                };
            });

builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireClaim("Role", UserRole.Admin.ToString()));
            
                options.AddPolicy("UserOrAdmin", policy =>
                    policy.RequireAssertion(context =>
                        context.User.HasClaim(c =>
                            c.Type == "Role" &&
                            (c.Value == UserRole.Admin.ToString() || c.Value == UserRole.User.ToString()))));
            });

builder.Services.AddSingleton<APIContext>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var config = new Dictionary<string, string>
            {
                { "clientId", Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID") },
                { "clientSecret", Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET") },
                { "mode", configuration["paypal:Mode"] }
            };

    var accessToken = new OAuthTokenCredential(config).GetAccessToken();
    return new APIContext(accessToken) { Config = config };
});
builder.Services.AddControllers().AddApplicationPart(typeof(AuthController).Assembly);


builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ITokenGeneratorService, JwtGeneratorService>();
builder.Services.AddScoped<IPasswordService, Argon2PasswordService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IPaginationService, PaginationService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentGatewayService, PayPalGatewayService>();
builder.Services.AddScoped<IEmailService, EmailService.PaymentSuccessfulEmailService>();
builder.Services.AddScoped<IInvoiceService, InvoicePDFService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<CustomExceptionHandlingMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

