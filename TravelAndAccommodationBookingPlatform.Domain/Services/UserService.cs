using AutoMapper;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IRepositories;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
using TravelAndAccommodationBookingPlatform.Domain.Models.UserDtos;

namespace TravelAndAccommodationBookingPlatform.Domain.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
        }
        return _mapper.Map<UserDto>(user);
    }
}