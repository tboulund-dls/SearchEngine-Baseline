using UserApi.Models;

namespace UserApi.Data;

public interface IUserRepository
{
    public User GetUser(string username, string password);
}