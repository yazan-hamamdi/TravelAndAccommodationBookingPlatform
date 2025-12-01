using System;
using System.Collections.Generic;
namespace TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
public interface IPaginationService
{
    public Task<(IEnumerable<T> Items, int TotalCount)> PaginateAsync<T>(IQueryable<T> query, int pageSize, int pageNumber) where T : class;
}