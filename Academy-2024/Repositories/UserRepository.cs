using Academy_2024.Data;
using Academy_2024.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2024.Repositories
{
    public class UserRepository
    {
        private readonly Applicationdbcontent _content;

        public UserRepository() { _content = new Applicationdbcontent(); }

        public List<User> GetAll() { return _content.Users.ToList(); }

        public List<User> GetAdults() { return _content.Users.Where(user => user.Age > 18).ToList(); }

        public User? GetById(int id) => _content.Users.FirstOrDefault(user => user.Id == id);

        public void Create(User data)
        {
            _content.Users.Add(data);
            _content.SaveChanges();
        }

        public User? Update(int id, User data)
        {
            var user = _content.Users.FirstOrDefault(user => user.Id == id);
            if ( user != null )
            {
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Email = data.Email;
                user.Age = data.Age;
                user.Password = data.Password;

                _content.SaveChanges();

                return user;
            }
            return null;

        }

        public bool Delete(int id)
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
