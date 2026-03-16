using UsersService.Api.Models;

namespace UsersService.Api.Services;

public class UserService : IUserService
{
    public IEnumerable<UserDto> GetUsers()
    {
        return new List<UserDto>
        {
            new()
            {
                Id = 1,
                Name = "Admin User",
                Email = "admin@abc.com",
                Role = "Administrator"
            },
            new()
            {
                Id = 2,
                Name = "Regular User",
                Email = "user@abc.com",
                Role = "User"
            }
        };
    }
}