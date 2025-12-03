using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
public interface ICityRepository : IBaseRepository<City>
{
    Task<List<City>> GetTrendingDestinationsAsync(int count);
    Task<(IEnumerable<City> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize);
    Task<City> GetCityByNameAsync(string cityName);
}