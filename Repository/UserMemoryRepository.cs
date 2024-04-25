using Domain;
using System.Linq;

namespace Repository
{
    public class UserMemoryRepository : IRepository<User>
    {
        private List<User> _users;

        public UserMemoryRepository()
        {
            _users = new List<User>
            {
                new User()
                {
                    Username = "admin",
                    Password = "admin"
                }
                
            };
        }

        public User Add(User oneElement)
        {
            oneElement.Id = _users.OrderByDescending(x => x.Id)
                .Select(x => x.Id)
                .FirstOrDefault() + 1;
            _users.Add(oneElement);
            return oneElement;
        }

        public User? Find(Func<User, bool> filter)
        {
            return _users.Where(filter).FirstOrDefault();
        }

        public IList<User> FindAll()
        {
            return _users;
        }

        public User? Update(User updatedEntity)
        {
            var index = _users.FindIndex(x => x.Id == updatedEntity.Id);
            if (index != -1)
            {
                _users[index] = updatedEntity;
                return _users[index];
            }
            return null;
        }
        public void Delete(int id)
        {
            _users.RemoveAll(x => x.Id == id);
        }
    }
}