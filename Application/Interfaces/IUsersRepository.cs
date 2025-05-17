public interface IUsersRepository
{
    Task<User> CreateUser(User user);

    Task<User> GetUserById(Guid userId);

    Task<IEnumerable<User>> GetAllUsers();

    Task<User> UpdateUser(Guid userId, UserDTO userDTO);

    Task DeleteUser(Guid userId);
}