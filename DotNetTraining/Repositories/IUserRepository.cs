using DotNetTraining.Models;

namespace DotNetTraining.Repositories
{
    public interface IUserRepository
    {

        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task SaveUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task UpdateUserAsync(User user, Guid userId);
        Task<User> GetUserByEmailAsync(string email);




    }
}
