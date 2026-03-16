using UsersService.Api.Models;

namespace UsersService.Api.Services;

public interface IUserService
{
    IEnumerable<UserDto> GetUsers();
}