
using Microsoft.EntityFrameworkCore;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UsersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetUserById(Guid userId)
    {
        User user = await _dbContext.Users.FirstOrDefaultAsync(id => id.Equals(userId));
        
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> UpdateUser(Guid userId, UserDTO userDTO)
    {
        User user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(userId));
        user.Username = userDTO.UserName;
        user.Email = userDTO.Email;
        await _dbContext.SaveChangesAsync();

        return user;
    }


        public async Task DeleteUser(Guid userId)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null) return;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
}