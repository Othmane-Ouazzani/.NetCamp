using DotNetTraining.Data;
using DotNetTraining.Models;
using Microsoft.EntityFrameworkCore;


namespace DotNetTraining.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
            return user;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async  Task SaveUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateUserAsync(User user, Guid userId)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Id.Equals(userId));
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
            }
        }

    }
}
