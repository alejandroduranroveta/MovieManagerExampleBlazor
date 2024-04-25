using Domain;

namespace BusinessLogic;

public class CurrentUser
{
    public User User { get; private set; }

    public void SetUser(User user)
    {
        User = user;
    }
    public void LogOut()
    {
        User = null;
    }
    
}