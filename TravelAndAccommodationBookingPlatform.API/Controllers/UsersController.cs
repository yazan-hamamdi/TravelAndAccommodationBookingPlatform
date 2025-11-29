using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.API.Validators.AuthValidators;
using TravelAndAccommodationBookingPlatform.Domain.Interfaces.IServices;
using TravelAndAccommodationBookingPlatform.Domain.Models.UserDtos;

namespace TravelAndAccommodationBookingPlatform.API.Controllers;
[ApiController]
[Route("api/users")]
[Authorize(Policy = "UserOrAdmin")]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="userId"> The ID of the user. </param>
    /// <returns> User details </returns>
    /// <response code="200"> User details </response>
    /// <response code="401"> Unauthorized </response>
    /// <response code="403">if the user id in the token does not match the user id in the request</response>
    /// <response code="404"> User not found </response>
    [ValidateUserId]
    [HttpGet("{userId}")]
    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
        return await _userService.GetUserByIdAsync(userId);
    }
}