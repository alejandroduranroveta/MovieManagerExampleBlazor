using Domain;
using Repository;

namespace BusinessLogic;

public class UserLogic
{
    private readonly IRepository<User> _repository;

    public UserLogic(IRepository<User> userRepository)
    {
        _repository = userRepository;
    }
    public User AddUser(User user)
    {

        return _repository.Add(user);
    }

    public IList<User> GetAll()
    {
        return _repository.FindAll();
    }
    
    public User FindById(int id)
    {
        return _repository.Find(x => x.Id == id);
    }
    public User ValidateUser(User user)
    {
        return _repository.Find(x => x.Username == user.Username && x.Password == user.Password);
    }
}