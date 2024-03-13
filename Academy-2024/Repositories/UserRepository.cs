using Academy_2024.Data;
using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _content;

        public UserRepository(ApplicationDbContext content) { _content = content; }

        public Task<List<User>> GetAllAsync() => _content.Users.ToListAsync();

        public Task<List<User>> GetAdultsAsync() => _content.Users.Where(user => (user.BirthDay - DateTime.Now).Days > 6570).ToListAsync();

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
                user.Name = data.Name;
                user.Email = data.Email;
                user.Role = data.Role;
                user.BirthDay = data.BirthDay;
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
