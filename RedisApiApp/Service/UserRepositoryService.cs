using RedisApiApp.Models;
using RedisApiApp.Service.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace RedisApiApp.Service;

public class UserRepositoryService : IUserRepositoryService
{

    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    private const string UserCounterKey = "counter:user";
    private const string UserIdKey = "user:id";
    private const string UserKeyPrefix = "user:";

    public UserRepositoryService(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = redis.GetDatabase();
    }

    public async Task AddUserASync(User user)
    {
        user.Id = (await _database.StringIncrementAsync(UserCounterKey)).ToString();
        var json = JsonSerializer.Serialize(user);
        await _database.StringSetAsync(UserKeyPrefix + user.Id, json);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var server = _redis.GetServer(_redis.GetEndPoints().First());
        var keys = server.Keys(pattern: UserKeyPrefix + "*");

        var users = new List<User>();

        foreach (var key in keys)
        {
            // Ignorar la clave del contador
            if (key.ToString() == UserIdKey)
                continue;

            var value = await _database.StringGetAsync(key);
            if (value.HasValue)
            {
                var user = JsonSerializer.Deserialize<User>(value);
                if (user is not null)
                    users.Add(user);
            }
        }
        return users;
    }
}
