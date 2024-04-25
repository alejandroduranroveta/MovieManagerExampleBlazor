using Domain;
using Repository;

namespace UserInterface.Data;

public class SessionLogic
{
    public SessionLogic(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    private readonly IRepository<User> _userRepository;
    public User CurrentUser { get; set; }
    
    public void Login(User anyUser)
    {
        CurrentUser = anyUser;
    }
    public bool ValidateCredentials(User user)
    {
        var existingUser = _userRepository.Find(u => u.Username == user.Username && u.Password == user.Password);
        return existingUser != null;
    }
    public void LogOut() 
    {
        CurrentUser = null;
    }
}