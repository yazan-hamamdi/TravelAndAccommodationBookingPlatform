using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Models.SearchDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
public interface IHotelRepository : IBaseRepository<Hotel>
{
    Task<(IEnumerable<Hotel>, int TotalCount)> SearchHotelsAsync(SearchRequestDto searchRequest, int pageSize, int pageNumber);
    Task<List<Hotel>> GetFeaturedDealsAsync(int count);
    Task<(IEnumerable<Hotel> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize);
}