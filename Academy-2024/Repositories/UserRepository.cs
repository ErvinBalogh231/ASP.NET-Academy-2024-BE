using Academy_2024.Data;
using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2024.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _content;

        public UserRepository(ApplicationDbContext content) { _content = content; }

        public Task<List<User>> GetAllAsync() => _content.Users.ToListAsync();

        public Task<List<User>> GetAdultsAsync() => _content.Users.Where(user => user.Age > 18).ToListAsync();

        public Task<User?> GetByIdAsync(int id) => _content.Users.FirstOrDefaultAsync(user => user.Id == id);

        public async Task CreateAsync(User data)
        {
            await _content.Users.AddAsync(data);
            await _content.SaveChangesAsync();
        }

        public async Task<User?> UpdateAsync(int id, User data)
        {
            var user = await _content.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Email = data.Email;
                user.Age = data.Age;
                user.Password = data.Password;

                await _content.SaveChangesAsync();

                return user;
            }
            return null;

        }



        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _content.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                _content.Users.Remove(user);
                await _content.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
