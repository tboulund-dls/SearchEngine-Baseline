using UserApi.Models;

namespace UserApi.Data;

public class UserRepository : IUserRepository
{
    private readonly UserApiContext context;
    public UserRepository(UserApiContext ctx)
    {
        context = ctx;
    }

    public User GetUser(string username, string password)
    {
        return context.Users.Where(user => user.username == username && user.password == password).FirstOrDefault();
    }
}