using Academy_2024.Data;
using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2024.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Applicationdbcontent _content;

        public UserRepository(Applicationdbcontent content) { _content = content; }

        public Task<List<User>> GetAllAsync() => _content.Users.ToListAsync();


        //public List<User> GetAdultsAsync() { return _content.Users.Where(user => user.Age > 18).ToList(); }

        public Task<User?> GetByAsync(int id) => _content.Users.FirstOrDefault(user => );

        public Task<User?> GetByIdAsync(int id) => _content.Users.FirstOrDefault(user => user.Id == id);

        public async Task CreateAsync(User data)
        {
            await _content.Users.AddAsync(data);
            await _content.SaveChangesAsync();
        }

        public Task<User?> UpdateAsync(int id, User data)
        {
            var user = _content.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Email = data.Email;
                user.Age = data.Age;
                user.Password = data.Password;

                _content.SaveChanges();

                return async user;
            }
            return null;

        }



        public async Task<bool> DeleteAsync(int id)
        {
            var user = _content.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                _content.Users.Remove(user);
                _content.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
