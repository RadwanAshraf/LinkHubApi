using LinkHubApi.CodeFirstMigration.Entities;
using LinkHubApi.Entities.ViewModel;

namespace LinkHubApi.Services
{
    public interface IUserService
    {
        Task<List<UserDto>?> GetUsersAsync();
        Task<User?> GetUserById(int id);
        Task<User?> AddUserAsync(User user);
        Task<User?> UpdateUserAsync(int id, User user);
        User? DeleteUser(int id);
        bool UserExists(string username);

    }
}
