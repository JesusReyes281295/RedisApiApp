using RedisApiApp.Models;

namespace RedisApiApp.Service.Interfaces;

public interface IUserRepositoryService
{
    Task AddUserASync(User user);
    Task<IEnumerable<User>> GetAllUsersAsync();
}
